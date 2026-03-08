/**
 * ═══════════════════════════════════════════════════════════
 * ENTERPRISE SUITE — LAYOUT.JS
 * Handles: Sidebar, Menu, Content Loading, Theme, Dropdowns
 * Dependencies: None (Vanilla JS) | Compatible with jQuery/Kendo
 * ═══════════════════════════════════════════════════════════
 */

(function () {
  'use strict';

  /* ══════════════════════════════════════
     CONFIGURATION
  ══════════════════════════════════════ */
  const CONFIG = {
    menuApiUrl: '/Menu/GetSidebarMenu',        // Server endpoint for menu JSON
    contentBaseUrl: '',                    // Base URL for content pages
    storageKeys: {
      theme: 'es_theme',
      sidebarCollapsed: 'es_sidebar_collapsed',
      activeMenuId: 'es_active_menu'
    },
    breakpointMobile: 768,
    animationDuration: 250
  };

  /* ══════════════════════════════════════
     DOM REFERENCES
  ══════════════════════════════════════ */
  const DOM = {
    html: document.documentElement,
    body: document.body,
    sidebar: document.getElementById('appSidebar'),
    sidebarToggle: document.getElementById('sidebarToggle'),
    sidebarOverlay: document.getElementById('sidebarOverlay'),
    navList: document.getElementById('navList'),
    appMain: document.getElementById('appMain'),
    contentArea: document.getElementById('contentArea'),
    contentLoader: document.getElementById('contentLoader'),
    logoZone: document.getElementById('logoZone'),
    logoText: document.getElementById('logoText'),
    themeToggleBtn: document.getElementById('themeToggleBtn'),
    themeIcon: document.getElementById('themeIcon'),
    userAvatarBtn: document.getElementById('userAvatarBtn'),
    userDropdown: document.getElementById('userDropdown'),
    notificationBtn: document.getElementById('notificationBtn'),
    notificationBadge: document.getElementById('notificationBadge'),
    notificationPanel: document.getElementById('notificationPanel'),
    settingsBtn: document.getElementById('settingsBtn'),
    markAllRead: document.getElementById('markAllRead'),
    currentDateTime: document.getElementById('currentDateTime'),
    globalSearch: document.getElementById('globalSearch')
  };

  /* ══════════════════════════════════════
     STATE
  ══════════════════════════════════════ */
  const STATE = {
    isMobile: false,
    sidebarCollapsed: false,
    mobileSidebarOpen: false,
    activeMenuId: null,
    currentTheme: 'light',
    menuData: [],
    notificationCount: 5
  };

  /* ══════════════════════════════════════
     INITIALIZATION
  ══════════════════════════════════════ */
  function init() {
    detectMobile();
    restoreTheme();
    restoreSidebarState();
    loadMenuFromServer();
    bindEvents();
    startClock();
    handleResize();
    window.addEventListener('resize', debounce(handleResize, 200));
  }

  /* ══════════════════════════════════════
     MOBILE DETECTION
  ══════════════════════════════════════ */
  function detectMobile() {
    STATE.isMobile = window.innerWidth <= CONFIG.breakpointMobile;
  }

  function handleResize() {
    const wasMobile = STATE.isMobile;
    STATE.isMobile = window.innerWidth <= CONFIG.breakpointMobile;

    if (!STATE.isMobile && wasMobile) {
      // Desktop — close mobile drawer
      closeMobileSidebar();
    }
  }

  /* ══════════════════════════════════════
     SIDEBAR — DESKTOP COLLAPSE/EXPAND
  ══════════════════════════════════════ */
  function restoreSidebarState() {
    const collapsed = localStorage.getItem(CONFIG.storageKeys.sidebarCollapsed);
    if (collapsed === 'true' && !STATE.isMobile) {
      DOM.body.classList.add('sidebar-collapsed');
      STATE.sidebarCollapsed = true;
    }
  }

  function toggleSidebar() {
    if (STATE.isMobile) {
      toggleMobileSidebar();
      return;
    }

    STATE.sidebarCollapsed = !STATE.sidebarCollapsed;

    if (STATE.sidebarCollapsed) {
      DOM.body.classList.add('sidebar-collapsed');
      localStorage.setItem(CONFIG.storageKeys.sidebarCollapsed, 'true');
      // Close all open submenus when collapsing
      closeAllSubmenus();
    } else {
      DOM.body.classList.remove('sidebar-collapsed');
      localStorage.setItem(CONFIG.storageKeys.sidebarCollapsed, 'false');
    }
  }

  /* ══════════════════════════════════════
     SIDEBAR — MOBILE DRAWER
  ══════════════════════════════════════ */
  function toggleMobileSidebar() {
    if (STATE.mobileSidebarOpen) {
      closeMobileSidebar();
    } else {
      openMobileSidebar();
    }
  }

  function openMobileSidebar() {
    STATE.mobileSidebarOpen = true;
    DOM.sidebar.classList.add('mobile-open');
    DOM.sidebarOverlay.classList.add('active');
    DOM.body.style.overflow = 'hidden';
  }

  function closeMobileSidebar() {
    STATE.mobileSidebarOpen = false;
    DOM.sidebar.classList.remove('mobile-open');
    DOM.sidebarOverlay.classList.remove('active');
    DOM.body.style.overflow = '';
  }

  /* ══════════════════════════════════════
     MENU — LOAD FROM SERVER
  ══════════════════════════════════════ */
  async function loadMenuFromServer() {
    try {
      const response = await fetch(CONFIG.menuApiUrl, {
        method: 'GET',
        headers: {
          'Accept': 'application/json',
          'X-Requested-With': 'XMLHttpRequest'
        },
        credentials: 'same-origin'
      });

      if (!response.ok) throw new Error(`HTTP ${response.status}`);

      const data = await response.json();
      STATE.menuData = data;
      renderMenu(data);
      restoreActiveMenu();

    } catch (error) {
      console.error('[Menu] Failed to load:', error);
      renderMenuError();
    }
  }

  /* ══════════════════════════════════════
     MENU — RENDER
     Expected JSON structure:
     [
       {
         "id": "crm",
         "label": "CRM",
         "icon": "fa-solid fa-briefcase",
         "section": "Business",        // optional — section divider
         "badge": null,                 // optional — badge text/count
         "url": null,                   // null if has children
         "permission": true,
         "children": [
           {
             "id": "crm-contacts",
             "label": "Contacts",
             "icon": "fa-solid fa-address-book",
             "url": "/CRM/Contacts",
             "permission": true,
             "badge": "12",
             "children": [
               {
                 "id": "crm-contacts-add",
                 "label": "Add Contact",
                 "icon": "fa-solid fa-plus",
                 "url": "/CRM/Contacts/Add",
                 "permission": true
               }
             ]
           }
         ]
       }
     ]
  ══════════════════════════════════════ */
  function renderMenu(menuItems) {
    if (!DOM.navList) return;

    const fragment = document.createDocumentFragment();
    let currentSection = null;

    menuItems.forEach(item => {
      if (!item.permission) return;

      // Section divider
      if (item.section && item.section !== currentSection) {
        currentSection = item.section;
        const label = document.createElement('li');
        label.className = 'nav-section-label';
        label.textContent = item.section;
        fragment.appendChild(label);
      }

      fragment.appendChild(createNavItem(item, 0));
    });

    DOM.navList.innerHTML = '';
    DOM.navList.appendChild(fragment);
  }

  function createNavItem(item, depth) {
    const li = document.createElement('li');
    li.className = 'nav-item';
    li.dataset.id = item.id;
    if (item.url) li.dataset.url = item.url;
    if (item.children && item.children.length > 0) li.dataset.hasChildren = 'true';

    const hasChildren = item.children && item.children.length > 0;

    // Build nav-link
    const link = document.createElement('div');
    link.className = 'nav-link';
    link.setAttribute('role', 'button');
    link.setAttribute('tabindex', '0');
    link.setAttribute('aria-label', item.label);

    if (hasChildren) {
      link.setAttribute('aria-expanded', 'false');
    }

    // Icon
    if (item.icon) {
      const icon = document.createElement('i');
      icon.className = `${item.icon} nav-icon`;
      link.appendChild(icon);
    }

    // Label
    const label = document.createElement('span');
    label.className = 'nav-label';
    label.textContent = item.label;
    link.appendChild(label);

    // Badge
    if (item.badge) {
      const badge = document.createElement('span');
      badge.className = 'nav-badge';
      badge.textContent = item.badge;
      link.appendChild(badge);
    }

    // Arrow (if has children)
    if (hasChildren) {
      const arrow = document.createElement('i');
      arrow.className = 'fa-solid fa-chevron-right nav-arrow';
      link.appendChild(arrow);
    }

    li.appendChild(link);

    // Tooltip for collapsed state
    const tooltip = document.createElement('div');
    tooltip.className = 'nav-tooltip';
    tooltip.textContent = item.label;
    li.appendChild(tooltip);

    // Children / Submenu
    if (hasChildren) {
      const submenu = document.createElement('ul');
      submenu.className = 'nav-submenu';
      submenu.setAttribute('role', 'list');

      item.children.forEach(child => {
        if (child.permission !== false) {
          submenu.appendChild(createNavItem(child, depth + 1));
        }
      });

      li.appendChild(submenu);

      // Toggle submenu on click
      link.addEventListener('click', (e) => {
        e.preventDefault();
        toggleSubmenu(li);
      });

      link.addEventListener('keydown', (e) => {
        if (e.key === 'Enter' || e.key === ' ') {
          e.preventDefault();
          toggleSubmenu(li);
        }
      });

    } else if (item.url) {
      // Leaf node — load content
      link.addEventListener('click', (e) => {
        e.preventDefault();
        loadContent(item.url, li);
        if (STATE.isMobile) closeMobileSidebar();
      });

      link.addEventListener('keydown', (e) => {
        if (e.key === 'Enter') {
          e.preventDefault();
          loadContent(item.url, li);
          if (STATE.isMobile) closeMobileSidebar();
        }
      });
    }

    return li;
  }

  function renderMenuError() {
    if (!DOM.navList) return;
    DOM.navList.innerHTML = `
            <li style="padding:16px 12px; color: #ef4444; font-size:12px; display:flex; align-items:center; gap:8px;">
                <i class="fa-solid fa-triangle-exclamation"></i>
                <span>Failed to load menu. Please refresh.</span>
            </li>`;
  }

  /* ══════════════════════════════════════
     MENU — SUBMENU ACCORDION
  ══════════════════════════════════════ */
  function toggleSubmenu(navItem) {
    const isOpen = navItem.classList.contains('open');
    const link = navItem.querySelector(':scope > .nav-link');

    if (isOpen) {
      closeSubmenu(navItem);
    } else {
      // Close sibling submenus at same level
      const siblings = navItem.parentElement.querySelectorAll(':scope > .nav-item.open');
      siblings.forEach(s => closeSubmenu(s));
      openSubmenu(navItem);
    }
  }

  function openSubmenu(navItem) {
    navItem.classList.add('open');
    const link = navItem.querySelector(':scope > .nav-link');
    if (link) link.setAttribute('aria-expanded', 'true');
  }

  function closeSubmenu(navItem) {
    navItem.classList.remove('open');
    const link = navItem.querySelector(':scope > .nav-link');
    if (link) link.setAttribute('aria-expanded', 'false');
  }

  function closeAllSubmenus() {
    if (!DOM.navList) return;
    DOM.navList.querySelectorAll('.nav-item.open').forEach(item => {
      closeSubmenu(item);
    });
  }

  /* ══════════════════════════════════════
     MENU — ACTIVE STATE
  ══════════════════════════════════════ */
  function setActiveNavItem(clickedItem) {
    // Clear all active
    if (DOM.navList) {
      DOM.navList.querySelectorAll('.nav-item.active').forEach(item => {
        item.classList.remove('active');
      });
    }

    // Set active on clicked item
    clickedItem.classList.add('active');
    STATE.activeMenuId = clickedItem.dataset.id;
    localStorage.setItem(CONFIG.storageKeys.activeMenuId, STATE.activeMenuId);

    // Walk up and highlight parent items + keep them open
    let parent = clickedItem.parentElement;
    while (parent && parent !== DOM.navList) {
      if (parent.classList.contains('nav-submenu')) {
        const parentItem = parent.parentElement;
        if (parentItem && parentItem.classList.contains('nav-item')) {
          parentItem.classList.add('active');
          openSubmenu(parentItem);
        }
      }
      parent = parent.parentElement;
    }
  }

  function restoreActiveMenu() {
    const savedId = localStorage.getItem(CONFIG.storageKeys.activeMenuId);
    if (!savedId || !DOM.navList) return;

    const item = DOM.navList.querySelector(`.nav-item[data-id="${savedId}"]`);
    if (item && item.dataset.url) {
      setActiveNavItem(item);
    }
  }

  /* ══════════════════════════════════════
     CONTENT LOADING — fetch()
  ══════════════════════════════════════ */
  async function loadContent(url, navItem) {
    if (!url) return;

    setActiveNavItem(navItem);
    showLoader();

    try {
      const response = await fetch(url, {
        method: 'GET',
        headers: {
          'X-Requested-With': 'XMLHttpRequest',
          'Accept': 'text/html'
        },
        credentials: 'same-origin'
      });

      if (!response.ok) throw new Error(`HTTP ${response.status}: ${response.statusText}`);

      const html = await response.text();

      // Scroll main back to top
      DOM.appMain.scrollTop = 0;

      // Inject HTML
      DOM.contentArea.innerHTML = html;

      // Re-initialize Kendo widgets if any
      reinitKendoWidgets(DOM.contentArea);

      // Update browser URL without reload
      history.pushState({ url, menuId: navItem.dataset.id }, '', url);

    } catch (error) {
      console.error('[Content] Load failed:', error);
      DOM.contentArea.innerHTML = buildErrorPage(url, error.message);
    } finally {
      hideLoader();
    }
  }

  function showLoader() {
    if (DOM.contentLoader) {
      DOM.contentLoader.classList.add('loading');
      DOM.contentLoader.setAttribute('aria-hidden', 'false');
    }
  }

  function hideLoader() {
    if (DOM.contentLoader) {
      DOM.contentLoader.classList.remove('loading');
      DOM.contentLoader.setAttribute('aria-hidden', 'true');
    }
  }

  function buildErrorPage(url, message) {
    return `
        <div style="display:flex;flex-direction:column;align-items:center;justify-content:center;
                    min-height:400px;text-align:center;padding:40px;">
            <div style="width:64px;height:64px;background:#fef2f2;border-radius:16px;
                        display:flex;align-items:center;justify-content:center;
                        font-size:28px;color:#ef4444;margin-bottom:20px;">
                <i class="fa-solid fa-triangle-exclamation"></i>
            </div>
            <h3 style="font-size:18px;font-weight:600;color:var(--text-primary);margin-bottom:8px;">
                Failed to Load Page
            </h3>
            <p style="font-size:13px;color:var(--text-muted);max-width:360px;line-height:1.6;margin-bottom:20px;">
                Could not load <code>${url}</code>.<br>${message}
            </p>
            <button onclick="history.back()"
                    style="padding:8px 20px;background:var(--brand-primary);color:white;
                           border-radius:6px;font-size:13px;font-weight:500;cursor:pointer;border:none;">
                Go Back
            </button>
        </div>`;
  }

  /* ══════════════════════════════════════
     KENDO RE-INIT
  ══════════════════════════════════════ */
  function reinitKendoWidgets(container) {
    // If Kendo is loaded, re-init any uninitialized widgets
    if (typeof kendo !== 'undefined') {
      // Kendo will handle its own auto-init via data-role attributes
      // For manual components, use a custom event
      const event = new CustomEvent('content:loaded', { detail: { container } });
      document.dispatchEvent(event);
    }
  }

  /* ══════════════════════════════════════
     THEME TOGGLE — Kendo Default v2
  ══════════════════════════════════════ */
  const KENDO_THEMES = {
    light: 'https://kendo.cdn.telerik.com/themes/9.0.0/default/default-main.css',
    dark: 'https://kendo.cdn.telerik.com/themes/9.0.0/default/default-main-dark.css'
  };

  function restoreTheme() {
    const saved = localStorage.getItem(CONFIG.storageKeys.theme) || 'light';
    applyTheme(saved, false);
  }

  function applyTheme(theme, animate = true) {
    STATE.currentTheme = theme;
    DOM.html.setAttribute('data-theme', theme);
    localStorage.setItem(CONFIG.storageKeys.theme, theme);

    // Update theme icon
    if (DOM.themeIcon) {
      DOM.themeIcon.className = theme === 'dark' ? 'fa-solid fa-moon' : 'fa-solid fa-sun';
    }

    // Swap Kendo theme CSS
    swapKendoTheme(theme);

    if (animate) {
      DOM.html.style.transition = 'background 0.3s ease, color 0.3s ease';
      setTimeout(() => { DOM.html.style.transition = ''; }, 400);
    }
  }

  function swapKendoTheme(theme) {
    const kendoLink = document.querySelector('link[href*="kendo.cdn.telerik.com/themes"]');
    if (kendoLink) {
      kendoLink.href = KENDO_THEMES[theme] || KENDO_THEMES.light;
    }
  }

  function toggleTheme() {
    const newTheme = STATE.currentTheme === 'light' ? 'dark' : 'light';
    applyTheme(newTheme, true);
  }

  /* ══════════════════════════════════════
     USER DROPDOWN
  ══════════════════════════════════════ */
  function openUserDropdown() {
    if (!DOM.userDropdown || !DOM.userAvatarBtn) return;
    closeNotificationPanel(); // close notification if open
    DOM.userDropdown.classList.add('open');
    DOM.userAvatarBtn.setAttribute('aria-expanded', 'true');
    DOM.userDropdown.setAttribute('aria-hidden', 'false');
  }

  function closeUserDropdown() {
    if (!DOM.userDropdown || !DOM.userAvatarBtn) return;
    DOM.userDropdown.classList.remove('open');
    DOM.userAvatarBtn.setAttribute('aria-expanded', 'false');
    DOM.userDropdown.setAttribute('aria-hidden', 'true');
  }

  function isUserDropdownOpen() {
    return DOM.userDropdown && DOM.userDropdown.classList.contains('open');
  }

  /* ══════════════════════════════════════
     NOTIFICATION PANEL
  ══════════════════════════════════════ */
  function openNotificationPanel() {
    if (!DOM.notificationPanel) return;
    closeUserDropdown(); // close user dropdown if open
    DOM.notificationPanel.classList.add('open');
    DOM.notificationPanel.setAttribute('aria-hidden', 'false');
    DOM.notificationBtn.classList.add('active');
  }

  function closeNotificationPanel() {
    if (!DOM.notificationPanel) return;
    DOM.notificationPanel.classList.remove('open');
    DOM.notificationPanel.setAttribute('aria-hidden', 'true');
    DOM.notificationBtn.classList.remove('active');
  }

  function isNotificationPanelOpen() {
    return DOM.notificationPanel && DOM.notificationPanel.classList.contains('open');
  }

  function markAllNotificationsRead() {
    STATE.notificationCount = 0;
    updateNotificationBadge();

    // Remove unread class from all items
    document.querySelectorAll('.notification-item.unread').forEach(item => {
      item.classList.remove('unread');
    });
  }

  function updateNotificationBadge() {
    if (!DOM.notificationBadge) return;
    if (STATE.notificationCount > 0) {
      DOM.notificationBadge.textContent = STATE.notificationCount > 99 ? '99+' : STATE.notificationCount;
      DOM.notificationBadge.style.display = 'flex';
      DOM.notificationBtn.classList.add('has-new');
    } else {
      DOM.notificationBadge.style.display = 'none';
      DOM.notificationBtn.classList.remove('has-new');
    }
  }

  /* ══════════════════════════════════════
     SETTINGS BUTTON
  ══════════════════════════════════════ */
  function openSettings() {
    // Load settings partial or navigate
    // Customize this based on your settings page URL
    console.log('[Settings] Open settings panel');
    // Example: loadContentByUrl('/Settings/Index');
  }

  /* ══════════════════════════════════════
     USER DROPDOWN ACTIONS
  ══════════════════════════════════════ */
  function handleDropdownAction(action) {
    closeUserDropdown();

    switch (action) {
      case 'profile':
        // loadContentByUrl('/Account/Profile');
        console.log('[User] Open profile');
        break;
      case 'changePassword':
        // loadContentByUrl('/Account/ChangePassword');
        console.log('[User] Change password');
        break;
      case 'preferences':
        // loadContentByUrl('/Account/Preferences');
        console.log('[User] Open preferences');
        break;
      case 'logout':
        if (confirm('Are you sure you want to sign out?')) {
          window.location.href = '/Account/Logout';
        }
        break;
    }
  }

  /* ══════════════════════════════════════
     SEARCH — Keyboard Shortcut
  ══════════════════════════════════════ */
  function handleSearchShortcut(e) {
    if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
      e.preventDefault();
      if (DOM.globalSearch) {
        DOM.globalSearch.focus();
        DOM.globalSearch.select();
      }
    }

    if (e.key === 'Escape') {
      closeAllPanels();
      if (DOM.globalSearch && document.activeElement === DOM.globalSearch) {
        DOM.globalSearch.blur();
      }
    }
  }

  function closeAllPanels() {
    closeUserDropdown();
    closeNotificationPanel();
  }

  /* ══════════════════════════════════════
     FOOTER CLOCK
  ══════════════════════════════════════ */
  function startClock() {
    function updateClock() {
      if (!DOM.currentDateTime) return;
      const now = new Date();
      DOM.currentDateTime.textContent = now.toLocaleString('en-US', {
        weekday: 'short',
        year: 'numeric',
        month: 'short',
        day: 'numeric',
        hour: '2-digit',
        minute: '2-digit',
        second: '2-digit'
      });
    }
    updateClock();
    setInterval(updateClock, 1000);
  }

  /* ══════════════════════════════════════
     BROWSER BACK/FORWARD
  ══════════════════════════════════════ */
  function handlePopState(e) {
    if (e.state && e.state.url) {
      // Find the menu item and activate it
      const menuItem = DOM.navList
        ? DOM.navList.querySelector(`.nav-item[data-url="${e.state.url}"]`)
        : null;

      if (menuItem) {
        setActiveNavItem(menuItem);
      }

      // Reload content
      showLoader();
      fetch(e.state.url, {
        headers: { 'X-Requested-With': 'XMLHttpRequest' },
        credentials: 'same-origin'
      })
        .then(r => r.text())
        .then(html => {
          DOM.appMain.scrollTop = 0;
          DOM.contentArea.innerHTML = html;
          reinitKendoWidgets(DOM.contentArea);
        })
        .catch(() => { })
        .finally(() => hideLoader());
    }
  }

  /* ══════════════════════════════════════
     PUBLIC API — expose for external use
  ══════════════════════════════════════ */
  window.EnterpriseLayout = {
    loadContent: function (url) {
      const fakeItem = document.createElement('li');
      fakeItem.className = 'nav-item';
      fakeItem.dataset.url = url;
      fakeItem.dataset.id = url;
      loadContent(url, fakeItem);
    },
    setActiveMenu: function (menuId) {
      const item = DOM.navList
        ? DOM.navList.querySelector(`.nav-item[data-id="${menuId}"]`)
        : null;
      if (item) setActiveNavItem(item);
    },
    updateNotificationCount: function (count) {
      STATE.notificationCount = count;
      updateNotificationBadge();
    },
    refreshMenu: function () {
      loadMenuFromServer();
    }
  };

  /* ══════════════════════════════════════
     EVENT BINDING
  ══════════════════════════════════════ */
  function bindEvents() {

    // Sidebar toggle
    if (DOM.sidebarToggle) {
      DOM.sidebarToggle.addEventListener('click', toggleSidebar);
    }

    // Sidebar overlay (mobile close)
    if (DOM.sidebarOverlay) {
      DOM.sidebarOverlay.addEventListener('click', closeMobileSidebar);
    }

    // Theme toggle
    if (DOM.themeToggleBtn) {
      DOM.themeToggleBtn.addEventListener('click', toggleTheme);
    }

    // Settings button
    if (DOM.settingsBtn) {
      DOM.settingsBtn.addEventListener('click', openSettings);
    }

    // User avatar — toggle dropdown
    if (DOM.userAvatarBtn) {
      DOM.userAvatarBtn.addEventListener('click', (e) => {
        e.stopPropagation();
        if (isUserDropdownOpen()) {
          closeUserDropdown();
        } else {
          openUserDropdown();
        }
      });
    }

    // User dropdown items
    if (DOM.userDropdown) {
      DOM.userDropdown.addEventListener('click', (e) => {
        const item = e.target.closest('[data-action]');
        if (item) {
          e.preventDefault();
          handleDropdownAction(item.dataset.action);
        }
      });
    }

    // Notification button
    if (DOM.notificationBtn) {
      DOM.notificationBtn.addEventListener('click', (e) => {
        e.stopPropagation();
        if (isNotificationPanelOpen()) {
          closeNotificationPanel();
        } else {
          openNotificationPanel();
        }
      });
    }

    // Mark all notifications read
    if (DOM.markAllRead) {
      DOM.markAllRead.addEventListener('click', (e) => {
        e.preventDefault();
        markAllNotificationsRead();
      });
    }

    // Global click — close panels
    document.addEventListener('click', (e) => {
      if (!e.target.closest('#userMenuWrapper')) closeUserDropdown();
      if (!e.target.closest('#notificationBtn') && !e.target.closest('#notificationPanel')) {
        closeNotificationPanel();
      }
    });

    // Keyboard shortcuts
    document.addEventListener('keydown', handleSearchShortcut);

    // Browser back/forward
    window.addEventListener('popstate', handlePopState);

    // Notification badge init
    updateNotificationBadge();
  }

  /* ══════════════════════════════════════
     UTILITIES
  ══════════════════════════════════════ */
  function debounce(fn, delay) {
    let timer;
    return function (...args) {
      clearTimeout(timer);
      timer = setTimeout(() => fn.apply(this, args), delay);
    };
  }

  /* ══════════════════════════════════════
     BOOT
  ══════════════════════════════════════ */
  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', init);
  } else {
    init();
  }

})();

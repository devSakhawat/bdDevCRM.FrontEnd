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
    menuApiUrl: '/Menu/GetSidebarMenu',
    contentBaseUrl: '',
    storageKeys: {
      theme: 'es_theme',
      sidebarCollapsed: 'es_sidebar_collapsed',
      activeMenuId: 'es_active_menu'
    },
    breakpointMobile: 768,
    animationDuration: 250,

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
    globalSearch: document.getElementById('globalSearch'),
    sidebarFooterInfo: document.getElementById('sidebarFooterInfo'),

    // Sidebar Search
    sidebarSearchInput: document.getElementById('sidebarSearchInput'),
    sidebarSearchClear: document.getElementById('sidebarSearchClear'),
    sidebarSearchMeta: document.getElementById('sidebarSearchMeta'),

    // Command Palette
    commandPaletteOverlay: document.getElementById('commandPaletteOverlay'),
    commandPalette: document.getElementById('commandPalette'),
    cpSearchInput: document.getElementById('cpSearchInput'),
    cpResultsArea: document.getElementById('cpResultsArea'),
    cpRecentSection: document.getElementById('cpRecentSection'),
    cpRecentList: document.getElementById('cpRecentList'),
    cpSearchSection: document.getElementById('cpSearchSection'),
    cpSearchList: document.getElementById('cpSearchList'),
    cpSearchResultLabel: document.getElementById('cpSearchResultLabel'),
    cpNoResults: document.getElementById('cpNoResults'),
    cpNoResultsQuery: document.getElementById('cpNoResultsQuery'),
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
    notificationCount: 5,
    // Sidebar Search && Command Palette
    recentMenus: [],      // Recently visited menu items
    cpFocusedIndex: -1,      // Command palette keyboard nav
    cpCurrentResults: [],      // Current CP search results
    maxRecentMenus: 10        // How many recent item
  };

  /* ══════════════════════════════════════
     INITIALIZATION
  ══════════════════════════════════════ */
  function init() {
    detectMobile();
    restoreTheme();
    restoreSidebarState();
    loadRecentMenus();
    loadMenuFromServer();
    bindEvents();
    startClock();
    handleResize();
    renderTidyUpButton();
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
      // ── Section divider (when only section) ──
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
      //icon.className = `${item.icon} nav-icon`;
      icon.className = `${resolveMenuIcon(item.label, item.icon)} nav-icon`;
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

  // layout.js-এ এই helper function যোগ করুন
  function resolveMenuIcon(label, existingIcon) {
    // Server থেকে আসা icon যদি generic হয় তাহলে override করো
    if (existingIcon && existingIcon !== 'fa-solid fa-briefcase') {
      return existingIcon; // Server-এর icon ঠিক আছে, সেটাই ব্যবহার করো
    }

    // Label দেখে icon assign করো
    const iconMap = {
      'home': 'fa-solid fa-house',
      'dashboard': 'fa-solid fa-gauge-high',
      'system admin': 'fa-solid fa-shield-halved',
      'menu settings': 'fa-solid fa-bars',
      'module settings': 'fa-solid fa-cubes',
      'user settings': 'fa-solid fa-users-gear',
      'group settings': 'fa-solid fa-user-lock',
      'system settings': 'fa-solid fa-gear',
      'access settings': 'fa-solid fa-key',
      'access restriction': 'fa-solid fa-ban',
      'access permission report': 'fa-solid fa-file-shield',
      'sbu settings': 'fa-solid fa-building',
      'work flow settings': 'fa-solid fa-diagram-project',
      'device setup': 'fa-solid fa-desktop',
      'hris settings': 'fa-solid fa-sliders',
      'currency': 'fa-solid fa-coins',
      'payment method': 'fa-solid fa-credit-card',
      'quary analyzer information': 'fa-solid fa-magnifying-glass-chart',
      'institute type': 'fa-solid fa-school',
      'intake month': 'fa-solid fa-calendar',
      'intake year': 'fa-solid fa-calendar-days',
    };

    const key = label.toLowerCase().trim();
    return iconMap[key] || 'fa-solid fa-circle-dot'; // default icon
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
    updateTidyUpButton();
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
  //function setActiveNavItem(clickedItem) {
  //  // Clear all active
  //  if (DOM.navList) {
  //    DOM.navList.querySelectorAll('.nav-item.active').forEach(item => {
  //      item.classList.remove('active');
  //    });
  //  }

  //  // Set active on clicked item
  //  clickedItem.classList.add('active');
  //  STATE.activeMenuId = clickedItem.dataset.id;
  //  localStorage.setItem(CONFIG.storageKeys.activeMenuId, STATE.activeMenuId);

  //  // Walk up and highlight parent items + keep them open
  //  let parent = clickedItem.parentElement;
  //  while (parent && parent !== DOM.navList) {
  //    if (parent.classList.contains('nav-submenu')) {
  //      const parentItem = parent.parentElement;
  //      if (parentItem && parentItem.classList.contains('nav-item')) {
  //        parentItem.classList.add('active');
  //        openSubmenu(parentItem);
  //      }
  //    }
  //    parent = parent.parentElement;
  //  }
  //}

  function setActiveNavItem(clickedItem) {
    // ── All active class remove ────────────────────────────────────
    if (DOM.navList) {
      DOM.navList.querySelectorAll('.nav-item.active').forEach(item => {
        item.classList.remove('active');
      });
    }

    // ── Clicked item active  ──────────────────────────────────
    clickedItem.classList.add('active');
    STATE.activeMenuId = clickedItem.dataset.id;
    localStorage.setItem(CONFIG.storageKeys.activeMenuId, STATE.activeMenuId);

    // ── Find Root parent and highlight it ──
    const rootParent = findRootParent(clickedItem);
    if (rootParent && rootParent !== clickedItem) {
      rootParent.classList.add('active');
    }

    // ── সব ancestor open রাখো (accordion collapse হবে না) ────────
    // কিন্তু active class শুধু root এবং clicked item-এ
    let parent = clickedItem.parentElement;
    while (parent && parent !== DOM.navList) {
      if (parent.classList.contains('nav-submenu')) {
        const parentItem = parent.parentElement;
        if (parentItem && parentItem.classList.contains('nav-item')) {
          openSubmenu(parentItem); // open রাখো
          // active class দেবো না — শুধু root parent পাবে
        }
      }
      parent = parent.parentElement;
    }
  }

  function findRootParent(navItem) {
    let current = navItem;
    let rootParent = null;

    while (current && current !== DOM.navList) {
      if (
        current.classList.contains('nav-item') &&
        current.parentElement === DOM.navList
      ) {
        // এটাই root level item — navList এর direct child
        rootParent = current;
        break;
      }
      current = current.parentElement;
    }

    return rootParent;
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
  //function handleSearchShortcut(e) {
  //  if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
  //    e.preventDefault();
  //    if (DOM.globalSearch) {
  //      DOM.globalSearch.focus();
  //      DOM.globalSearch.select();
  //    }
  //  }

  //  if (e.key === 'Escape') {
  //    closeAllPanels();
  //    if (DOM.globalSearch && document.activeElement === DOM.globalSearch) {
  //      DOM.globalSearch.blur();
  //    }
  //  }
  //}

  function handleSearchShortcut(e) {

    // ── Ctrl+K → Command Palette open/close ──────────────────────
    if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
      e.preventDefault();
      e.stopPropagation();

      if (DOM.commandPaletteOverlay &&
        DOM.commandPaletteOverlay.classList.contains('open')) {
        closeCommandPalette();
      } else {
        openCommandPalette();
      }
      return;
    }

    // ── ESC → সব close করো ───────────────────────────────────────
    if (e.key === 'Escape') {
      if (DOM.commandPaletteOverlay &&
        DOM.commandPaletteOverlay.classList.contains('open')) {
        closeCommandPalette();
        return;
      }
      closeAllPanels();
      clearSidebarSearch();
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

    // Notification badge init
    updateNotificationBadge();

    // ── Sidebar Search ───────────────────────────────────────────
    initSidebarSearch();

    // ── Command Palette ──────────────────────────────────────────

    // Header search box click → Command Palette খোলে
    if (DOM.globalSearch) {
      DOM.globalSearch.addEventListener('focus', (e) => {
        e.preventDefault();
        DOM.globalSearch.blur();
        openCommandPalette();
      });
    }

    // Overlay click → close
    if (DOM.commandPaletteOverlay) {
      DOM.commandPaletteOverlay.addEventListener('click', (e) => {
        if (e.target === DOM.commandPaletteOverlay) closeCommandPalette();
      });
    }

    // CP Search input
    if (DOM.cpSearchInput) {
      DOM.cpSearchInput.addEventListener('input',
        debounce((e) => handleCPSearch(e.target.value), 150)
      );
      DOM.cpSearchInput.addEventListener('keydown', handleCPKeydown);
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

    // ESC hint click
    const escHint = document.querySelector('.cp-esc-hint');
    if (escHint) escHint.addEventListener('click', closeCommandPalette);

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
   SIDEBAR — TIDY UP TOGGLE BUTTON
══════════════════════════════════════ */

  function renderTidyUpButton() {
    if (!DOM.sidebarFooterInfo) return;

    const btn = document.createElement('button');
    btn.className = 'tidy-up-btn';
    btn.id = 'tidyUpBtn';
    btn.setAttribute('title', 'Open / Close All Menus');
    btn.setAttribute('aria-label', 'Toggle all menus');

    btn.innerHTML = `
        <i class="fa-solid fa-bars-staggered tidy-icon"></i>
        <span class="tidy-label">Collapse All</span>
    `;

    btn.addEventListener('click', handleTidyUpClick);

    // sidebar-footer-info এর শুরুতে insert করো
    DOM.sidebarFooterInfo.insertBefore(btn, DOM.sidebarFooterInfo.firstChild);
  }

  function handleTidyUpClick() {
    if (!DOM.navList) return;

    // ── সব open menu খুঁজে বের করো ──────────────────────────────
    const allOpenItems = Array.from(
      DOM.navList.querySelectorAll('.nav-item.open')
    );

    const hasOpenMenus = allOpenItems.length > 0;

    if (hasOpenMenus) {
      // ════════════════════════════════════════════════════════
      // Scenario 1: কিছু menu open আছে
      // Active menu-র parent chain ছাড়া বাকি সব close করো
      // ════════════════════════════════════════════════════════

      // Active item-এর সব ancestor (parent chain) collect করো
      const activeAncestors = getActiveAncestors();

      allOpenItems.forEach(item => {
        // Active menu-র ancestor হলে open রাখো, নইলে close করো
        if (!activeAncestors.has(item)) {
          closeSubmenu(item);
        }
      });

    } else {
      // ════════════════════════════════════════════════════════
      // Scenario 2: সব menu closed আছে
      // সব parent menu (children আছে এমন) open করো recursively
      // ════════════════════════════════════════════════════════
      const allParentItems = DOM.navList.querySelectorAll(
        '.nav-item[data-has-children="true"]'
      );

      allParentItems.forEach(item => openSubmenu(item));
    }

    // Button label/icon update করো
    updateTidyUpButton();
  }

  // Active menu-র সব ancestor collect করো (parent chain)
  function getActiveAncestors() {
    const ancestors = new Set();
    if (!DOM.navList) return ancestors;

    // Active item খুঁজো
    const activeItem = DOM.navList.querySelector('.nav-item.active');
    if (!activeItem) return ancestors;

    // Active item থেকে উপরে উপরে যাও, সব parent collect করো
    let current = activeItem.parentElement;
    while (current && current !== DOM.navList) {
      if (current.classList.contains('nav-item')) {
        ancestors.add(current);
      }
      current = current.parentElement;
    }

    return ancestors;
  }

  // Button এর icon ও label update করো current state অনুযায়ী
  function updateTidyUpButton() {
    const btn = document.getElementById('tidyUpBtn');
    if (!btn) return;

    const hasOpenMenus = DOM.navList
      ? DOM.navList.querySelectorAll('.nav-item.open').length > 0
      : false;

    const icon = btn.querySelector('.tidy-icon');
    const label = btn.querySelector('.tidy-label');

    if (hasOpenMenus) {
      // কিছু open আছে → Collapse করার option দেখাও
      if (icon) icon.className = 'fa-solid fa-bars-staggered tidy-icon';
      if (label) label.textContent = 'Collapse All';
      btn.setAttribute('title', 'Collapse open menus');
    } else {
      // সব closed → Expand করার option দেখাও
      if (icon) icon.className = 'fa-solid fa-expand tidy-icon';
      if (label) label.textContent = 'Expand All';
      btn.setAttribute('title', 'Expand all menus');
    }
  }

  /* ══════════════════════════════════════════════════════
   SIDEBAR SEARCH
══════════════════════════════════════════════════════ */

  // Flat list তৈরি করো সব leaf + parent menu থেকে (search এর জন্য)
  function buildFlatMenuList(items, parentPath = []) {
    const flat = [];

    items.forEach(item => {
      const currentPath = [...parentPath, item.label];

      if (item.url) {
        // Leaf node — searchable item
        flat.push({
          id: item.id,
          label: item.label,
          url: item.url,
          icon: item.icon,
          path: currentPath,           // ['CRM', 'Contacts', 'All Contacts']
          pathStr: currentPath.join(' '), // search এর জন্য
        });
      }

      if (item.children && item.children.length > 0) {
        const children = buildFlatMenuList(item.children, currentPath);
        flat.push(...children);
      }
    });

    return flat;
  }

  function initSidebarSearch() {
    if (!DOM.sidebarSearchInput) return;

    DOM.sidebarSearchInput.addEventListener('input', debounce(handleSidebarSearch, 200));

    DOM.sidebarSearchInput.addEventListener('keydown', (e) => {
      if (e.key === 'Escape') {
        clearSidebarSearch();
        DOM.sidebarSearchInput.blur();
      }
    });

    if (DOM.sidebarSearchClear) {
      DOM.sidebarSearchClear.addEventListener('click', () => {
        clearSidebarSearch();
        DOM.sidebarSearchInput.focus();
      });
    }
  }

  function handleSidebarSearch() {
    const rawQuery = DOM.sidebarSearchInput
      ? DOM.sidebarSearchInput.value.trim().toLowerCase()
      : '';

    // Clear button visibility
    if (DOM.sidebarSearchClear) {
      DOM.sidebarSearchClear.classList.toggle('visible', rawQuery.length > 0);
    }

    if (!rawQuery) {
      clearSidebarSearch();
      return;
    }

    if (!DOM.navList) return;

    // ── Token split — space দিয়ে আলাদা করো ──────────────────────
    // "crm admin" → ["crm", "admin"]
    // একাধিক space হলেও handle হবে
    const tokens = rawQuery
      .split(/\s+/)
      .filter(t => t.length > 0);

    // ── Section labels hide করো search mode-এ ────────────────────
    DOM.navList.querySelectorAll('.nav-section-label').forEach(el => {
      el.style.display = 'none';
    });

    // ── প্রথমে সব items visible করো ──────────────────────────────
    DOM.navList.querySelectorAll('.nav-item').forEach(item => {
      item.classList.remove('search-hidden');
    });

    let matchCount = 0;

    // ── প্রতিটা leaf nav-item check করো ─────────────────────────
    // Leaf = url আছে এমন item (child item)
    const allItems = DOM.navList.querySelectorAll('.nav-item');

    allItems.forEach(item => {
      const labelEl = item.querySelector(':scope > .nav-link > .nav-label');
      if (!labelEl) return;

      // এই item-এর full path text তৈরি করো
      // নিজের label + সব parent-এর label মিলিয়ে
      const fullPath = getItemFullPath(item).toLowerCase();

      // ── AND logic — সব token fullPath-এ থাকতে হবে ───────────
      const allTokensMatch = tokens.every(token => fullPath.includes(token));

      if (allTokensMatch) {
        matchCount++;
        item.classList.remove('search-hidden');

        // ── Label-এ match হওয়া tokens highlight করো ─────────
        let labelText = labelEl.textContent;
        tokens.forEach(token => {
          labelText = labelText.replace(
            new RegExp(`(${escapeRegex(token)})`, 'gi'),
            '<mark class="search-highlight">$1</mark>'
          );
        });
        labelEl.innerHTML = labelText;

        // ── Parent chain দেখাও এবং open করো ─────────────────
        showParentChain(item);

      } else {
        // Children check — এই parent-এর কোনো child match করে কিনা
        // এটা parent items এর জন্য — নিচে আলাদা pass-এ handle হবে
        item.classList.add('search-hidden');
      }
    });

    // ── Second pass — parent items যাদের visible child আছে ───────
    // নিচ থেকে উপরে উঠে যাও
    const allNavItems = Array.from(
      DOM.navList.querySelectorAll('.nav-item')
    ).reverse(); // reverse করো যেন child আগে process হয়

    allNavItems.forEach(item => {
      const hasVisibleChild = item.querySelector(
        '.nav-submenu .nav-item:not(.search-hidden)'
      );

      if (hasVisibleChild) {
        item.classList.remove('search-hidden');
        openSubmenu(item); // accordion open করো
      }
    });

    // ── Match count update ────────────────────────────────────────
    if (DOM.sidebarSearchMeta) {
      if (matchCount > 0) {
        const tokenDisplay = tokens.join(' + ');
        DOM.sidebarSearchMeta.textContent =
          `${matchCount} result${matchCount > 1 ? 's' : ''} for "${tokenDisplay}"`;
      } else {
        DOM.sidebarSearchMeta.textContent = 'No results found';
      }
    }
  }

  // ── Helper: item-এর full path text বের করো ───────────────────────
  // Example: "CRM > Contacts > All Contacts" → "crm contacts all contacts"
  // এই combined text-এ AND token search হয়
  function getItemFullPath(navItem) {
    const parts = [];

    // নিজের label
    const labelEl = navItem.querySelector(':scope > .nav-link > .nav-label');
    if (labelEl) parts.push(labelEl.textContent.trim());

    // সব parent-এর label collect করো
    let current = navItem.parentElement;
    while (current && current !== DOM.navList) {
      if (current.classList.contains('nav-item')) {
        const parentLabel = current.querySelector(
          ':scope > .nav-link > .nav-label'
        );
        if (parentLabel) parts.push(parentLabel.textContent.trim());
      }
      current = current.parentElement;
    }

    return parts.join(' ');
  }

  function showParentChain(navItem) {
    let current = navItem.parentElement;
    while (current && current !== DOM.navList) {
      if (current.classList.contains('nav-item')) {
        current.classList.remove('search-hidden');
      }
      if (current.classList.contains('nav-submenu')) {
        const parentItem = current.parentElement;
        if (parentItem) {
          parentItem.classList.remove('search-hidden');
          openSubmenu(parentItem);
        }
      }
      current = current.parentElement;
    }
  }

  function clearSidebarSearch() {
    if (!DOM.navList) return;

    // সব items restore করো
    DOM.navList.querySelectorAll('.nav-item').forEach(item => {
      item.classList.remove('search-hidden');
    });

    // Section labels restore করো
    DOM.navList.querySelectorAll('.nav-section-label').forEach(el => {
      el.style.display = '';
    });

    // Highlight remove করো
    DOM.navList.querySelectorAll('mark.search-highlight').forEach(mark => {
      const parent = mark.parentNode;
      if (parent) {
        parent.replaceChild(
          document.createTextNode(mark.textContent),
          mark
        );
        parent.normalize();
      }
    });

    // Input clear
    if (DOM.sidebarSearchInput) DOM.sidebarSearchInput.value = '';
    if (DOM.sidebarSearchClear) DOM.sidebarSearchClear.classList.remove('visible');
    if (DOM.sidebarSearchMeta) DOM.sidebarSearchMeta.textContent = '';

    // Active menu-র parent reopen করো
    const activeItem = DOM.navList.querySelector('.nav-item.active');
    if (activeItem) {
      let parent = activeItem.parentElement;
      while (parent && parent !== DOM.navList) {
        if (parent.classList.contains('nav-submenu')) {
          const parentItem = parent.parentElement;
          if (parentItem) openSubmenu(parentItem);
        }
        parent = parent.parentElement;
      }
    }
  }

  /* ══════════════════════════════════════════════════════
     COMMAND PALETTE
  ══════════════════════════════════════════════════════ */

  function openCommandPalette() {
    if (!DOM.commandPaletteOverlay) return;
    DOM.commandPaletteOverlay.classList.add('open');
    DOM.commandPaletteOverlay.setAttribute('aria-hidden', 'false');
    STATE.cpFocusedIndex = -1;

    // Recent menus দেখাও
    renderRecentMenus();

    // Input focus
    setTimeout(() => {
      if (DOM.cpSearchInput) {
        DOM.cpSearchInput.value = '';
        DOM.cpSearchInput.focus();
      }
      showCPSection('recent');
    }, 50);
  }

  function closeCommandPalette() {
    if (!DOM.commandPaletteOverlay) return;
    DOM.commandPaletteOverlay.classList.remove('open');
    DOM.commandPaletteOverlay.setAttribute('aria-hidden', 'true');
    STATE.cpFocusedIndex = -1;
    STATE.cpCurrentResults = [];
    if (DOM.cpSearchInput) DOM.cpSearchInput.value = '';
  }

  function showCPSection(section) {
    // 'recent' | 'search' | 'empty'
    if (DOM.cpRecentSection)
      DOM.cpRecentSection.style.display = section === 'recent' ? '' : 'none';
    if (DOM.cpSearchSection)
      DOM.cpSearchSection.style.display = section === 'search' ? '' : 'none';
    if (DOM.cpNoResults)
      DOM.cpNoResults.style.display = section === 'empty' ? '' : 'none';
  }

  // Recently visited menus render করো
  function renderRecentMenus() {
    if (!DOM.cpRecentList) return;

    const recent = STATE.recentMenus;

    if (recent.length === 0) {
      DOM.cpRecentList.innerHTML =
        `<li style="padding:12px 16px;font-size:12px;color:var(--text-muted);">
                No recently visited pages yet.
             </li>`;
      return;
    }

    DOM.cpRecentList.innerHTML = '';
    recent.forEach((item, index) => {
      DOM.cpRecentList.appendChild(
        buildCPResultItem(item, index, '')
      );
    });
  }

  // Command Palette search
  function handleCPSearch(query) {
    query = query.trim();
    STATE.cpFocusedIndex = -1;

    if (!query) {
      renderRecentMenus();
      showCPSection('recent');
      return;
    }

    // Flat menu list থেকে search করো
    const flatList = buildFlatMenuList(STATE.menuData);
    const lowerQ = query.toLowerCase();

    // Score করে sort করো — exact match সবার উপরে
    const results = flatList
      .map(item => {
        const labelLower = item.label.toLowerCase();
        const pathLower = item.pathStr.toLowerCase();
        let score = 0;

        if (labelLower === lowerQ) score = 100; // Exact
        else if (labelLower.startsWith(lowerQ)) score = 80;  // Starts with
        else if (labelLower.includes(lowerQ)) score = 60;  // Contains
        else if (pathLower.includes(lowerQ)) score = 40;  // Path contains

        return { ...item, score };
      })
      .filter(item => item.score > 0)
      .sort((a, b) => b.score - a.score)
      .slice(0, 20); // সর্বোচ্চ ২০টা result

    STATE.cpCurrentResults = results;

    if (results.length === 0) {
      if (DOM.cpNoResultsQuery) DOM.cpNoResultsQuery.textContent = query;
      showCPSection('empty');
      return;
    }

    // Result count label
    if (DOM.cpSearchResultLabel) {
      DOM.cpSearchResultLabel.textContent =
        `${results.length} result${results.length > 1 ? 's' : ''}`;
    }

    // Render results
    if (DOM.cpSearchList) {
      DOM.cpSearchList.innerHTML = '';
      results.forEach((item, index) => {
        DOM.cpSearchList.appendChild(
          buildCPResultItem(item, index, query)
        );
      });
    }

    showCPSection('search');
  }

  // একটা CP result item তৈরি করো
  function buildCPResultItem(item, index, query) {
    const li = document.createElement('li');
    li.className = 'cp-result-item';
    li.dataset.index = index;
    li.dataset.url = item.url || '';
    li.dataset.id = item.id || '';
    li.setAttribute('role', 'option');

    // Path string তৈরি করো (parent > parent > label)
    const pathParts = item.path || [item.label];
    const displayPath = pathParts.length > 1
      ? pathParts.slice(0, -1)
        .map(p => `<span>${p}</span>`)
        .join('<span class="path-sep">›</span>')
      : '';

    // Label highlight করো
    const highlightedLabel = query
      ? highlightText(item.label, query)
      : item.label;

    li.innerHTML = `
        <div class="cp-item-icon">
            <i class="${item.icon || 'fa-solid fa-circle-dot'}"></i>
        </div>
        <div class="cp-item-content">
            <div class="cp-item-label">${highlightedLabel}</div>
            ${displayPath
        ? `<div class="cp-item-path">${displayPath}</div>`
        : ''}
        </div>
        <i class="fa-solid fa-arrow-right cp-item-arrow"></i>
    `;

    // Click → content load করো
    li.addEventListener('click', () => {
      handleCPItemSelect(item);
    });

    return li;
  }

  function handleCPItemSelect(item) {
    if (!item.url) return;

    closeCommandPalette();

    // Recently visited-এ save করো
    addToRecentMenus(item);

    // Sidebar-এ active set করো
    if (DOM.navList && item.id) {
      const navItem = DOM.navList.querySelector(`.nav-item[data-id="${item.id}"]`);
      if (navItem) setActiveNavItem(navItem);
    }

    // Content load করো
    const cleanUrl = item.url.replace(/^\.\.\//, '/');
    showLoader();

    fetch(cleanUrl, {
      headers: { 'X-Requested-With': 'XMLHttpRequest' },
      credentials: 'same-origin'
    })
      .then(r => r.text())
      .then(html => {
        DOM.appMain.scrollTop = 0;
        DOM.contentArea.innerHTML = html;
        reinitKendoWidgets(DOM.contentArea);
        history.pushState({ url: cleanUrl, menuId: item.id }, '', cleanUrl);
      })
      .catch(() => {
        DOM.contentArea.innerHTML = buildErrorPage(cleanUrl, 'Load failed');
      })
      .finally(() => hideLoader());
  }

  // Recently visited manage করো
  function addToRecentMenus(item) {
    // Duplicate remove করো
    STATE.recentMenus = STATE.recentMenus.filter(r => r.id !== item.id);

    // নতুন item সবার উপরে
    STATE.recentMenus.unshift({
      id: item.id,
      label: item.label,
      url: item.url,
      icon: item.icon,
      path: item.path
    });

    // Max limit রাখো
    if (STATE.recentMenus.length > STATE.maxRecentMenus) {
      STATE.recentMenus = STATE.recentMenus.slice(0, STATE.maxRecentMenus);
    }

    // localStorage-এ save করো (session persist)
    try {
      localStorage.setItem('es_recent_menus', JSON.stringify(STATE.recentMenus));
    } catch (e) { /* ignore */ }
  }

  function loadRecentMenus() {
    try {
      const saved = localStorage.getItem('es_recent_menus');
      if (saved) STATE.recentMenus = JSON.parse(saved);
    } catch (e) {
      STATE.recentMenus = [];
    }
  }

  // Keyboard navigation
  function handleCPKeydown(e) {
    const isSearchMode = DOM.cpSearchSection &&
      DOM.cpSearchSection.style.display !== 'none';

    const list = isSearchMode ? DOM.cpSearchList : DOM.cpRecentList;
    const items = list ? Array.from(list.querySelectorAll('.cp-result-item')) : [];

    if (items.length === 0) return;

    if (e.key === 'ArrowDown') {
      e.preventDefault();
      STATE.cpFocusedIndex = Math.min(
        STATE.cpFocusedIndex + 1,
        items.length - 1
      );
      updateCPFocus(items);

    } else if (e.key === 'ArrowUp') {
      e.preventDefault();
      STATE.cpFocusedIndex = Math.max(STATE.cpFocusedIndex - 1, 0);
      updateCPFocus(items);

    } else if (e.key === 'Enter') {
      e.preventDefault();
      if (STATE.cpFocusedIndex >= 0 && items[STATE.cpFocusedIndex]) {
        items[STATE.cpFocusedIndex].click();
      }
    }
  }

  function updateCPFocus(items) {
    items.forEach((item, i) => {
      item.classList.toggle('cp-focused', i === STATE.cpFocusedIndex);
      if (i === STATE.cpFocusedIndex) {
        item.scrollIntoView({ block: 'nearest' });
      }
    });
  }

  // Text highlight helper
  function highlightText(text, query) {
    if (!query) return text;
    const escaped = escapeRegex(query);
    return text.replace(
      new RegExp(`(${escaped})`, 'gi'),
      '<mark>$1</mark>'
    );
  }

  function escapeRegex(str) {
    return str.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
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

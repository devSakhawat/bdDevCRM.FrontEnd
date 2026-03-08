# EnterpriseSuite — Layout Files
## File Structure

```
YourProject/
├── Views/
│   └── Shared/
│       └── _Layout.cshtml          ← Main layout
├── Views/
│   └── Home/
│       └── Index.cshtml            ← Default welcome page
├── Views/
│   └── CRM/Contacts/
│       └── _SamplePartial.cshtml   ← Example content partial
├── wwwroot/
│   ├── css/
│   │   └── layout.css              ← All layout styles
│   └── js/
│       └── layout.js               ← All layout JavaScript
└── Controllers/
    └── Api/
        └── MenuController.cs       ← Menu API + Models + Service
```

---

## Program.cs Registration (add to your DI container)

```csharp
// In Program.cs
builder.Services.AddScoped<IMenuService, MenuService>();
```

---

## How Content Loading Works

1. User clicks a menu item (leaf node with `url`)
2. `layout.js` calls `fetch(url, { headers: { 'X-Requested-With': 'XMLHttpRequest' } })`
3. Server detects AJAX request → returns Partial View (no layout)
4. JS injects HTML into `#contentArea`
5. Any Kendo widgets in the partial auto-initialize

### Detecting AJAX in Controller:
```csharp
public IActionResult Index()
{
    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        return PartialView("_ContactsPartial"); // returns partial only
    
    return View(); // returns full layout (direct URL access)
}
```

---

## Theme Toggle — Kendo Default v2

- **Light:** `default-main.css`  
- **Dark:** `default-main-dark.css`  

The JS swaps the Kendo `<link>` href automatically on toggle.  
User preference is saved to `localStorage`.

---

## Sidebar Behavior

| State | Desktop | Mobile (≤768px) |
|---|---|---|
| Expanded | 260px | Hidden (drawer closed) |
| Collapsed | 64px icon strip | Hidden (drawer closed) |
| Toggle click | Collapse/Expand | Open/Close drawer |
| Overlay click | — | Close drawer |

Collapsed state is saved to `localStorage` and restored on page load.

---

## Menu JSON Structure (from `/api/menu`)

```json
[
  {
    "id": "crm",
    "label": "CRM",
    "icon": "fa-solid fa-briefcase",
    "section": "Business",
    "url": null,
    "badge": null,
    "permission": true,
    "order": 10,
    "children": [
      {
        "id": "crm-contacts",
        "label": "Contacts",
        "icon": "fa-solid fa-address-book",
        "url": null,
        "permission": true,
        "order": 1,
        "children": [
          {
            "id": "crm-contacts-list",
            "label": "All Contacts",
            "icon": "fa-solid fa-list",
            "url": "/CRM/Contacts/Index",
            "permission": true,
            "order": 1
          }
        ]
      }
    ]
  }
]
```

---

## Public JS API (available globally)

```javascript
// Load any URL into main content
EnterpriseLayout.loadContent('/Reports/CRM');

// Set active menu item by id
EnterpriseLayout.setActiveMenu('crm-contacts-list');

// Update notification badge count
EnterpriseLayout.updateNotificationCount(7);

// Refresh the sidebar menu (e.g. after role change)
EnterpriseLayout.refreshMenu();
```

---

## CDN Dependencies

| Library | Version | Purpose |
|---|---|---|
| Kendo UI jQuery | 2024.3.1015 | UI Components |
| Kendo Default v2 Theme | 9.0.0 | Styling |
| jQuery | 3.7.1 | Kendo dependency |
| Font Awesome | 6.5.0 | Icons |
| DM Sans | Google Fonts | UI typography |
| Space Grotesk | Google Fonts | Brand/logo font |

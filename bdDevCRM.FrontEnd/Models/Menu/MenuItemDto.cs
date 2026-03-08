namespace bdDevCRM.FrontEnd.Models.Menu;

/// <summary>One node in the sidebar navigation tree.</summary>
public class MenuItemDto
{
  /// <summary>Unique identifier used for active-state tracking in JS.</summary>
  public string Id { get; set; } = string.Empty;

  /// <summary>Display label in the sidebar.</summary>
  public string Label { get; set; } = string.Empty;

  /// <summary>Font Awesome class string, e.g. "fa-solid fa-briefcase".</summary>
  public string Icon { get; set; } = string.Empty;

  /// <summary>Section divider label (optional). Groups items visually.</summary>
  public string? Section { get; set; }

  /// <summary>
  /// The URL to load via fetch() into the main content area.
  /// Null/empty if this item has children (acts as accordion parent).
  /// </summary>
  public string? Url { get; set; }

  /// <summary>Optional badge text displayed next to the label (e.g. "12", "New").</summary>
  public string? Badge { get; set; }

  /// <summary>
  /// Whether the current user has permission to see this item.
  /// Items where Permission=false are filtered out by the service and never sent.
  /// This flag exists for completeness/logging.
  /// </summary>
  public bool Permission { get; set; } = true;

  /// <summary>Sort order within parent.</summary>
  public int Order { get; set; }

  /// <summary>Nested children (Level 2 and Level 3).</summary>
  public List<MenuItemDto>? Children { get; set; }
}

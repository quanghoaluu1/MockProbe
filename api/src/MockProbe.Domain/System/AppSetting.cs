using MockProbe.Domain.Common;
using MockProbe.Domain.Enums;

namespace MockProbe.Domain.System;

public sealed class AppSetting : AuditableEntity
{
    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    public AppSettingValueType ValueType { get; set; } = AppSettingValueType.String;

    public string? Description { get; set; }

    public bool IsSecret { get; set; }
}

using System.ComponentModel;

namespace NGrib.Grib2.CodeTables;

/// <summary>
/// CODE TABLE 4.91 TYPE OF INTERVAL
/// </summary>
/// <remarks>Updated 12/21/2011</remarks>
public enum IntervalType
{
	/// <summary>Smaller than first limit</summary>
	[Description("Smaller than first limit")]
	SmallerThanFirstLimit = 0,

	/// <summary>Greater than second limit</summary>
	[Description("Greater than second limit")]
	GreaterThanSecondLimit = 1,

	/// <summary>Between first and second limit. The range includes the first limit but not the second limit.</summary>
	[Description("Between first and second limit. The range includes the first limit but not the second limit.")]
	BetweenFirstAndSecondLimit = 2,

	/// <summary>Greater than first limit</summary>
	[Description("Greater than first limit")]
	GreaterThanFirstLimit = 3,

	/// <summary>Smaller than second limit</summary>
	[Description("Smaller than second limit")]
	SmallerThanSecondLimit = 4,

	/// <summary>Smaller or equal first limit</summary>
	[Description("Smaller or equal first limit")]
	SmallerOrEqualFirstLimit = 5,

	/// <summary>Greater or equal second limit</summary>
	[Description("Greater or equal second limit")]
	GreaterOrEqualSecondLimit = 6,

	/// <summary>Between first and second limit. The range includes the first limit and the second limit.</summary>
	[Description("Between first and second limit. The range includes the first limit and the second limit.")]
	BetweenFirstAndSecondLimitInclusive = 7,

	/// <summary>Greater or equal first limit</summary>
	[Description("Greater or equal first limit")]
	GreaterOrEqualFirstLimit = 8,

	/// <summary>Smaller or equal second limit</summary>
	[Description("Smaller or equal second limit")]
	SmallerOrEqualSecondLimit = 9,

	/// <summary>Between first and second limit. The range includes the second limit but not the first limit.</summary>
	[Description("Between first and second limit. The range includes the second limit but not the first limit.")]
	BetweenFirstAndSecondLimitReversed = 10,

	/// <summary>Equal to first limit</summary>
	[Description("Equal to first limit")]
	EqualToFirstLimit = 11,

	/// <summary>Reserved for Local Use (192-254)</summary>
	[Description("Reserved for Local Use")]
	ReservedForLocalUse = 192,

	/// <summary>Missing</summary>
	[Description("Missing")]
	Missing = 255
}
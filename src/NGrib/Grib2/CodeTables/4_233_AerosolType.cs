using System.ComponentModel;

namespace NGrib.Grib2.CodeTables;

/// <summary>
/// CODE TABLE 4.233 AEROSOL TYPE
/// </summary>
/// <remarks>Revised 07/18/2022</remarks>
public enum AerosolType
{
	/// <summary>Ozone (O3)</summary>
	[Description("Ozone, O3")]
	Ozone = 0,

	/// <summary>Water Vapour (H2O)</summary>
	[Description("Water Vapour, H2O")]
	WaterVapour = 1,

	/// <summary>Methane (CH4)</summary>
	[Description("Methane, CH4")]
	Methane = 2,

	/// <summary>Carbon Dioxide (CO2)</summary>
	[Description("Carbon Dioxide, CO2")]
	CarbonDioxide = 3,

	/// <summary>Carbon Monoxide (CO)</summary>
	[Description("Carbon Monoxide, CO")]
	CarbonMonoxide = 4,

	/// <summary>Nitrogen Dioxide (NO2)</summary>
	[Description("Nitrogen Dioxide, NO2")]
	NitrogenDioxide = 5,

	/// <summary>Nitrous Oxide (N2O)</summary>
	[Description("Nitrous Oxide, N2O")]
	NitrousOxide = 6,

	/// <summary>Formaldehyde (HCHO)</summary>
	[Description("Formaldehyde, HCHO")]
	Formaldehyde = 7,

	/// <summary>Sulphur Dioxide (SO2)</summary>
	[Description("Sulphur Dioxide, SO2")]
	SulphurDioxide = 8,

	/// <summary>Ammonia (NH3)</summary>
	[Description("Ammonia, NH3")]
	Ammonia = 9,

	/// <summary>Ammonium (NH4+)</summary>
	[Description("Ammonium, NH4+")]
	Ammonium = 10,

	/// <summary>Nitrogen Monoxide (NO)</summary>
	[Description("Nitrogen Monoxide, NO")]
	NitrogenMonoxide = 11,

	/// <summary>Atomic Oxygen (O)</summary>
	[Description("Atomic Oxygen, O")]
	AtomicOxygen = 12,

	/// <summary>Nitrate Radical (NO3)</summary>
	[Description("Nitrate Radical, NO3")]
	NitrateRadical = 13,

	/// <summary>Hydroperoxyl Radical (HO2)</summary>
	[Description("Hydroperoxyl Radical, HO2")]
	HydroperoxylRadical = 14,

	/// <summary>Dinitrogen Pentoxide (H2O5)</summary>
	[Description("Dinitrogen Pentoxide, H2O5")]
	DinitrogenPentoxide = 15,

	/// <summary>Nitrous Acid (HONO)</summary>
	[Description("Nitrous Acid, HONO")]
	NitrousAcid = 16,

	/// <summary>Nitric Acid (HNO3)</summary>
	[Description("Nitric Acid, HNO3")]
	NitricAcid = 17,

	/// <summary>Peroxynitric Acid (HO2NO2)</summary>
	[Description("Peroxynitric Acid, HO2NO2")]
	PeroxynitricAcid = 18,

	/// <summary>Hydrogen Peroxide (H2O2)</summary>
	[Description("Hydrogen Peroxide, H2O2")]
	HydrogenPeroxide = 19,

	[Description("Molecular Hydrogen, H")]
	MolecularHydrogen = 20,

	/// <summary>Atomic Nitrogen (N)</summary>
	[Description("Atomic Nitrogen, N")]
	AtomicNitrogen = 21,

	/// <summary>Sulphate (SO4^2-)</summary>
	[Description("Sulphate, SO4^2-")]
	Sulphate = 22,

	/// <summary>Radon (Rn)</summary>
	[Description("Radon, Rn")]
	Radon = 23,

	/// <summary>Elemental Mercury (Hg(O))</summary>
	[Description("Elemental Mercury, Hg(O)")]
	ElementalMercury = 24,

	/// <summary>Divalent Mercury (Hg2+)</summary>
	[Description("Divalent Mercury, Hg2+")]
	DivalentMercury = 25,

	/// <summary>Atomic Chlorine (Cl)</summary>
	[Description("Atomic Chlorine, Cl")]
	AtomicChlorine = 26,

	/// <summary>Chlorine Monoxide (ClO)</summary>
	[Description("Chlorine Monoxide, ClO")]
	ChlorineMonoxide = 27,

	/// <summary>Dichlorine Peroxide (Cl2O2)</summary>
	[Description("Dichlorine Peroxide, Cl2O2")]
	DichlorinePeroxide = 28,

	/// <summary>Hypochlorous Acid (HClO)</summary>
	[Description("Hypochlorous Acid, HClO")]
	HypochlorousAcid = 29,

	/// <summary>Chlorine Nitrate (ClONO2)</summary>
	[Description("Chlorine Nitrate, ClONO2")]
	ChlorineNitrate = 30,

	/// <summary>Chlorine Dioxide (ClO2)</summary>
	[Description("Chlorine Dioxide, ClO2")]
	ChlorineDioxide = 31,

	/// <summary>Atomic Bromide (Br)</summary>
	[Description("Atomic Bromide, Br")]
	AtomicBromide = 32,

	/// <summary>Bromine Monoxide (BrO)</summary>
	[Description("Bromine Monoxide, BrO")]
	BromineMonoxide = 33,

	/// <summary>Bromine Chloride (BrCl)</summary>
	[Description("Bromine Chloride, BrCl")]
	BromineChloride = 34,

	/// <summary>Hydrogen Bromide (HBr)</summary>
	[Description("Hydrogen Bromide, HBr")]
	HydrogenBromide = 35,

	/// <summary>Hypobromous Acid (HBrO)</summary>
	[Description("Hypobromous Acid, HBrO")]
	HypobromousAcid = 36,

	/// <summary>Bromine Nitrate (BrONO2)</summary>
	[Description("Bromine Nitrate, BrONO2")]
	BromineNitrate = 37,

	/// <summary>Oxygen (O2)</summary>
	[Description("Oxygen, O2")]
	Oxygen = 38,

	/// <summary>Hydroxyl Radical (OH)</summary>
	[Description("Hydroxyl Radical, OH")]
	HydroxylRadical = 10000,

	/// <summary>Methyl Peroxy Radical (CH3O2)</summary>
	[Description("Methyl Peroxy Radical, CH3O2")]
	MethylPeroxyRadical = 10001,

	/// <summary>Methyl Hydroperoxide (CH3O2H)</summary>
	[Description("Methyl Hydroperoxide, CH3O2H")]
	MethylHydroperoxide = 10002,

	/// <summary>Methanol (CH3OH)</summary>
	[Description("Methanol, CH3OH")]
	Methanol = 10004,

	/// <summary>Formic Acid (CH3OOH)</summary>
	[Description("Formic Acid, CH3OOH")]
	FormicAcid = 10005,

	/// <summary>Hydrogen Cyanide (HCN)</summary>
	[Description("Hydrogen Cyanide, HCN")]
	HydrogenCyanide = 10006,

	/// <summary>Aceto Nitrile (CH3CN)</summary>
	[Description("Aceto Nitrile, CH3CN")]
	AcetoNitrile = 10007,

	/// <summary>Ethane (C2H6)</summary>
	[Description("Ethane, C2H6")]
	Ethane = 10008,

	/// <summary>Ethene (Ethylene) (C2H4)</summary>
	[Description("Ethene (Ethylene), C2H4")]
	Ethene = 10009,

	/// <summary>Ethyne (Acetylene) (C2H2)</summary>
	[Description("Ethyne (Acetylene), C2H2")]
	Ethyne = 10010,

	/// <summary>Ethanol (C2H5OH)</summary>
	[Description("Ethanol, C2H5OH")]
	Ethanol = 10011,

	/// <summary>Acetic Acid (C2H5OOH)</summary>
	[Description("Acetic Acid, C2H5OOH")]
	AceticAcid = 10012,

	/// <summary>Peroxyacetyl Nitrate (CH3C(O)OONO2)</summary>
	[Description("Peroxyacetyl Nitrate, CH3C(O)OONO2")]
	PeroxyacetylNitrate = 10013,

	/// <summary>Propane (C3H8)</summary>
	[Description("Propane, C3H8")]
	Propane = 10014,

	/// <summary>Propene (C3H6)</summary>
	[Description("Propene, C3H6")]
	Propene = 10015,

	/// <summary>Butanes (C4H10)</summary>
	[Description("Butanes, C4H10")]
	Butanes = 10016,

	/// <summary>Isoprene (C5H10)</summary>
	[Description("Isoprene, C5H10")]
	Isoprene = 10017,

	/// <summary>Alpha Pinene (C10H16)</summary>
	[Description("Alpha Pinene, C10H16")]
	AlphaPinene = 10018,

	/// <summary>Beta Pinene (C10H16)</summary>
	[Description("Beta Pinene, C10H16")]
	BetaPinene = 10019,

	/// <summary>Limonene (C10H16)</summary>
	[Description("Limonene, C10H16")]
	Limonene = 10020,

	/// <summary>Benzene (C6H6)</summary>
	[Description("Benzene, C6H6")]
	Benzene = 10021,

	/// <summary>Toluene (C7H8)</summary>
	[Description("Toluene, C7H8")]
	Toluene = 10022,

	/// <summary>Xylene (C8H10)</summary>
	[Description("Xylene, C8H10")]
	Xylene = 10023,

	/// <summary>Dimethyl Sulphide (CH3SCH3)</summary>
	[Description("Dimethyl Sulphide, CH3SCH3")]
	DimethylSulphide = 10500,

	/// <summary>Hydrogen Chloride (HCL)</summary>
	[Description("Hydrogen Chloride, HCL")]
	HydrogenChloride = 20001,

	/// <summary>CFC-11</summary>
	[Description("CFC-11")]
	CFC11 = 20002,

	/// <summary>CFC-12</summary>
	[Description("CFC-12")]
	CFC12 = 20003,

	/// <summary>CFC-113</summary>
	[Description("CFC-113")]
	CFC113 = 20004,

	/// <summary>CFC-113a</summary>
	[Description("CFC-113a")]
	CFC113a = 20005,

	/// <summary>CFC-114</summary>
	[Description("CFC-114")]
	CFC114 = 20006,

	/// <summary>CFC-115</summary>
	[Description("CFC-115")]
	CFC115 = 20007,

	/// <summary>HCFC-22</summary>
	[Description("HCFC-22")]
	HCFC22 = 20008,

	/// <summary>HCFC-141b</summary>
	[Description("HCFC-141b")]
	HCFC141b = 20009,

	/// <summary>HCFC-142b</summary>
	[Description("HCFC-142b")]
	HCFC142b = 20010,

	/// <summary>Halon-1202</summary>
	[Description("Halon-1202")]
	Halon1202 = 20011,

	/// <summary>Halon-1211</summary>
	[Description("Halon-1211")]
	Halon1211 = 20012,

	/// <summary>Halon-1301</summary>
	[Description("Halon-1301")]
	Halon1301 = 20013,

	/// <summary>Halon-2402</summary>
	[Description("Halon-2402")]
	Halon2402 = 20014,

	/// <summary>Methyl Chloride (HCC-40)</summary>
	[Description("Methyl Chloride, HCC-40")]
	MethylChloride = 20015,

	/// <summary>Carbon Tetrachloride (HCC-10)</summary>
	[Description("Carbon Tetrachloride, HCC-10")]
	CarbonTetrachloride = 20016,

	/// <summary>HCC-140a (CH3CCl3)</summary>
	[Description("HCC-140a, CH3CCl3")]
	HCC140a = 20017,

	/// <summary>Methyl Bromide (HBC-40B1)</summary>
	[Description("Methyl Bromide, HBC-40B1")]
	MethylBromide = 20018,

	/// <summary>Hexachlorocyclohexane (HCH)</summary>
	[Description("Hexachlorocyclohexane, HCH")]
	Hexachlorocyclohexane = 20019,

	/// <summary>Alpha Hexachlorocyclohexane</summary>
	[Description("Alpha Hexachlorocyclohexane")]
	AlphaHexachlorocyclohexane = 20020,

	/// <summary>Hexachlorobiphenyl (PCB-153)</summary>
	[Description("Hexachlorobiphenyl, PCB-153")]
	Hexachlorobiphenyl = 20021,

	/// <summary>Radioactive Pollutant (Tracer, defined by originating centre)</summary>
	[Description("Radioactive Pollutant (Tracer, defined by originating centre)")]
	RadioactivePollutant = 30000,

	/// <summary>HOx Radical (OH+HO2)</summary>
	[Description("HOx Radical, OH+HO2")]
	HOxRadical = 60000,

	/// <summary>Total Inorganic and Organic Peroxy Radicals (HO2+RO2)</summary>
	[Description("Total Inorganic and Organic Peroxy Radicals, HO2+RO2")]
	TotalPeroxyRadicals = 60001,

	/// <summary>Passive Ozone</summary>
	[Description("Passive Ozone")]
	PassiveOzone = 60002,

	/// <summary>NOx Expressed As Nitrogen</summary>
	[Description("NOx Expressed As Nitrogen")]
	NOxAsNitrogen = 60003,

	/// <summary>All Nitrogen Oxides (NOy) Expressed As Nitrogen</summary>
	[Description("All Nitrogen Oxides (NOy) Expressed As Nitrogen")]
	NOyAsNitrogen = 60004,

	/// <summary>Total Inorganic Chlorine</summary>
	[Description("Total Inorganic Chlorine")]
	TotalInorganicChlorine = 60005,

	/// <summary>Total Inorganic Bromine</summary>
	[Description("Total Inorganic Bromine")]
	TotalInorganicBromine = 60006,

	/// <summary>Total Inorganic Chlorine Except HCl, ClONO2: ClOx</summary>
	[Description("Total Inorganic Chlorine Except HCl, ClONO2: ClOx")]
	TotalInorganicChlorineExcept = 60007,

	/// <summary>Total Inorganic Bromine Except HBr, BrONO2:BrOx</summary>
	[Description("Total Inorganic Bromine Except HBr, BrONO2:BrOx")]
	TotalInorganicBromineExcept = 60008,

	/// <summary>Lumped Alkanes</summary>
	[Description("Lumped Alkanes")]
	LumpedAlkanes = 60009,

	/// <summary>Lumped Alkenes</summary>
	[Description("Lumped Alkenes")]
	LumpedAlkenes = 60010,

	/// <summary>Lumped Aromatic Compounds</summary>
	[Description("Lumped Aromatic Compounds")]
	LumpedAromaticCompounds = 60011,

	/// <summary>Lumped Terpenes</summary>
	[Description("Lumped Terpenes")]
	LumpedTerpenes = 60012,

	/// <summary>Non-Methane Volatile Organic Compounds Expressed as Carbon</summary>
	[Description("Non-Methane Volatile Organic Compounds, expressed as Carbon")]
	NMVOC = 60013,

	/// <summary>Anthropogenic Non-Methane Volatile Organic Compounds Expressed as Carbon</summary>
	[Description("Anthropogenic Non-Methane Volatile Organic Compounds, expressed as Carbon")]
	aNMVOC = 60014,

	/// <summary>Biogenic Non-Methane Volatile Organic Compounds Expressed as Carbon</summary>
	[Description("Biogenic Non-Methane Volatile Organic Compounds, expressed as Carbon")]
	bNMVOC = 60015,

	/// <summary>Lumped Oxygenated Hydrocarbons</summary>
	[Description("Lumped Oxygenated Hydrocarbons")]
	OVOC = 60016,

	/// <summary>Total Aerosol</summary>
	[Description("Total Aerosol")]
	TotalAerosol = 62000,

	/// <summary>Dust Dry</summary>
	[Description("Dust Dry")]
	DustDry = 62001,

	/// <summary>Water in Ambient</summary>
	[Description("Water in Ambient")]
	WaterInAmbient = 62002,

	/// <summary>Ammonium Dry</summary>
	[Description("Ammonium Dry")]
	AmmoniumDry = 62003,

	/// <summary>Nitrate Dry</summary>
	[Description("Nitrate Dry")]
	NitrateDry = 62004,

	/// <summary>Nitric Acid Trihydrate</summary>
	[Description("Nitric Acid Trihydrate")]
	NitricAcidTrihydrate = 62005,

	/// <summary>Sulphate Dry</summary>
	[Description("Sulphate Dry")]
	SulphateDry = 62006,

	/// <summary>Mercury Dry</summary>
	[Description("Mercury Dry")]
	MercuryDry = 62007,

	/// <summary>Sea Salt Dry</summary>
	[Description("Sea Salt Dry")]
	SeaSaltDry = 62008,

	/// <summary>Black Carbon Dry</summary>
	[Description("Black Carbon Dry")]
	BlackCarbonDry = 62009,

	/// <summary>Particulate Organic Matter Dry</summary>
	[Description("Particulate Organic Matter Dry")]
	ParticulateOrganicMatterDry = 62010,

	/// <summary>Primary Particulate Organic Matter Dry</summary>
	[Description("Primary Particulate Organic Matter Dry")]
	PrimaryParticulateOrganicMatterDry = 62011,

	/// <summary>Secondary Particulate Organic Matter Dry</summary>
	[Description("Secondary Particulate Organic Matter Dry")]
	SecondaryParticulateOrganicMatterDry = 62012,

	/// <summary>Black Carbon Hydrophilic Dry</summary>
	[Description("Black Carbon Hydrophilic Dry")]
	BlackCarbonHydrophilicDry = 62013,

	/// <summary>Black Carbon Hydrophobic Dry</summary>
	[Description("Black Carbon Hydrophobic Dry")]
	BlackCarbonHydrophobicDry = 62014,

	/// <summary>Particulate Organic Matter Hydrophilic Dry</summary>
	[Description("Particulate Organic Matter Hydrophilic Dry")]
	ParticulateOrganicMatterHydrophilicDry = 62015,

	/// <summary>Particulate Organic Matter Hydrophobic Dry</summary>
	[Description("Particulate Organic Matter Hydrophobic Dry")]
	ParticulateOrganicMatterHydrophobicDry = 62016,

	/// <summary>Nitrate Hydrophilic Dry</summary>
	[Description("Nitrate Hydrophilic Dry")]
	NitrateHydrophilicDry = 62017,

	/// <summary>Nitrate Hydrophobic Dry</summary>
	[Description("Nitrate Hydrophobic Dry")]
	NitrateHydrophobicDry = 62018,

	/// <summary>Smoke - High Absorption</summary>
	[Description("Smoke - High Absorption")]
	SmokeHighAbsorption = 62020,

	/// <summary>Smoke - Low Absorption</summary>
	[Description("Smoke - Low Absorption")]
	SmokeLowAbsorption = 62021,

	/// <summary>Aerosol - High Absorption</summary>
	[Description("Aerosol - High Absorption")]
	AerosolHighAbsorption = 62022,

	/// <summary>Aerosol - Low Absorption</summary>
	[Description("Aerosol - Low Absorption")]
	AerosolLowAbsorption = 62023,

	/// <summary>Volcanic Ash</summary>
	[Description("Volcanic Ash")]
	VolcanicAsh = 62025,

	/// <summary>Missing</summary>
	[Description("Missing")]
	Missing = 65535
}
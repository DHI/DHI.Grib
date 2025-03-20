﻿/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 *
 * NGrib is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * NGrib is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with NGrib.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace NGrib.Grib2.CodeTables
{
	/// <summary>
	/// Represents a parameter.
	/// </summary>
	public readonly struct Parameter
	{
		/// <summary>
		/// Parameter category.
		/// </summary>
		public ParameterCategory Category { get; }

		/// <summary>
		/// Parameter number.
		/// </summary>
		public int Code { get; }

		/// <summary>
		/// Parameter name.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Units.
		/// </summary>
		public string Unit { get; }

		/// <summary>
		/// Local use parameter flag.
		/// True if parameter is not part of the GRIB2 master code table, but specific to the issuing center (e.g. NCEP/NOAA or DWD).
		/// </summary>
		public bool LocalUse { get; }

		private Parameter(ParameterCategory category, int code, string name, string unit)
			: this(category, code, name, unit, false)
		{
		}

		internal Parameter(ParameterCategory category, int code, string name, string unit, bool localUse = true)
		{
			Category = category;
			Code = code;
			Name = name;
			Unit = unit;
			LocalUse = localUse;
		}

		public static Parameter? Get(Discipline d, int centerCode, int parameterCategory, int parameterNumber)
		{
			if (ParameterCategory.CategoriesByDiscipline.TryGetValue(d, out var categories))
			{
				var category = categories.Where(c => c.Code == parameterCategory).ToArray();
				if (category.Any() && ParametersByCategoryWithLocalTables(centerCode)
					    .TryGetValue(category[0], out var parameters))
				{
					var parameter = parameters.Where(p => p.Code == parameterNumber).ToArray();
					if (parameter.Any())
					{
						return parameter[0];
					}
				}
			}

			return null;
		}

		#region Product Discipline 0: Meteorological products, Parameter Category 0: Temperature

		///<summary>Temperature (K)</summary>
		public static Parameter Temperature { get; } = new Parameter(ParameterCategory.Temperature, 0, "Temperature", "K");

		///<summary>Virtual temperature (K)</summary>
		public static Parameter VirtualTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 1, "Virtual temperature", "K");

		///<summary>Potential temperature (K)</summary>
		public static Parameter PotentialTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 2, "Potential temperature", "K");

		///<summary>Pseudo-adiabatic potential temperature or equivalent potential temperature (K)</summary>
		public static Parameter PseudoAdiabaticPotentialTemperatureOrEquivalentPotentialTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 3,
				"Pseudo-adiabatic potential temperature or equivalent potential temperature", "K");

		///<summary>Maximum temperature (K)</summary>
		public static Parameter MaximumTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 4, "Maximum temperature", "K");

		///<summary>Minimum temperature (K)</summary>
		public static Parameter MinimumTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 5, "Minimum temperature", "K");

		///<summary>Dew point temperature (K)</summary>
		public static Parameter DewPointTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 6, "Dew point temperature", "K");

		///<summary>Dew point depression (or deficit) (K)</summary>
		public static Parameter DewPointDepression { get; } =
			new Parameter(ParameterCategory.Temperature, 7, "Dew point depression (or deficit)", "K");

		///<summary>Lapse rate (K m-1)</summary>
		public static Parameter LapseRate { get; } = new Parameter(ParameterCategory.Temperature, 8, "Lapse rate", "K m-1");

		///<summary>Temperature anomaly (K)</summary>
		public static Parameter TemperatureAnomaly { get; } =
			new Parameter(ParameterCategory.Temperature, 9, "Temperature anomaly", "K");

		///<summary>Latent heat net flux (W m-2)</summary>
		public static Parameter LatentHeatNetFlux { get; } =
			new Parameter(ParameterCategory.Temperature, 10, "Latent heat net flux", "W m-2");

		///<summary>Sensible heat net flux (W m-2)</summary>
		public static Parameter SensibleHeatNetFlux { get; } =
			new Parameter(ParameterCategory.Temperature, 11, "Sensible heat net flux", "W m-2");

		///<summary>Heat index (K)</summary>
		public static Parameter HeatIndex { get; } = new Parameter(ParameterCategory.Temperature, 12, "Heat index", "K");

		///<summary>Wind chill factor (K)</summary>
		public static Parameter WindChillFactor { get; } =
			new Parameter(ParameterCategory.Temperature, 13, "Wind chill factor", "K");

		///<summary>Minimum dew point depression (K)</summary>
		public static Parameter MinimumDewPointDepression { get; } =
			new Parameter(ParameterCategory.Temperature, 14, "Minimum dew point depression", "K");

		///<summary>Virtual potential temperature (K)</summary>
		public static Parameter VirtualPotentialTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 15, "Virtual potential temperature", "K");

		///<summary>Snow Phase Change Heat Flux (W m-2)</summary>
		public static Parameter SnowPhaseChangeHeatFlux { get; } =
			new Parameter(ParameterCategory.Temperature, 16, "Snow Phase Change Heat Flux", "W m-2");

		///<summary>Skin Temperature (K)</summary>
		public static Parameter SkinTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 17, "Skin Temperature", "K");

		///<summary>Snow Temperature (top of snow) (K)</summary>
		public static Parameter SnowTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 18, "Snow Temperature (top of snow)", "K");

		///<summary>Turbulent Transfer Coefficient for Heat (Numeric)</summary>
		public static Parameter TurbulentTransferCoefficientForHeat { get; } =
			new Parameter(ParameterCategory.Temperature, 19, "Turbulent Transfer Coefficient for Heat", "Numeric");

		///<summary>Turbulent Diffusion Coefficient for Heat (m2s-1)</summary>
		public static Parameter TurbulentDiffusionCoefficientForHeat { get; } =
			new Parameter(ParameterCategory.Temperature, 20, "Turbulent Diffusion Coefficient for Heat", "m2s-1");

		///<summary>Apparent Temperature  (K)</summary>
		public static Parameter ApparentTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 21, "Apparent Temperature ", "K");

		///<summary>Temperature Tendency due to Short-Wave Radiation (K s-1)</summary>
		public static Parameter TemperatureTendencyDueToShortWaveRadiation { get; } =
			new Parameter(ParameterCategory.Temperature, 22, "Temperature Tendency due to Short-Wave Radiation", "K s-1");

		///<summary>Temperature Tendency due to Long-Wave Radiation (K s-1)</summary>
		public static Parameter TemperatureTendencyDueToLongWaveRadiation { get; } =
			new Parameter(ParameterCategory.Temperature, 23, "Temperature Tendency due to Long-Wave Radiation", "K s-1");

		///<summary>Temperature Tendency due to Short-Wave Radiation,Clear Sky (K s-1)</summary>
		public static Parameter TemperatureTendencyDueToShortWaveRadiationClearSky { get; } =
			new Parameter(ParameterCategory.Temperature, 24, "Temperature Tendency due to Short-Wave Radiation,Clear Sky", "K s-1");

		///<summary>Temperature Tendency due to Long-Wave Radiation,Clear Sky (K s-1)</summary>
		public static Parameter TemperatureTendencyDueToLongWaveRadiationClearSky { get; } =
			new Parameter(ParameterCategory.Temperature, 25, "Temperature Tendency due to Long-Wave Radiation,Clear Sky", "K s-1");

		///<summary>Temperature Tendency due to parameterizations (K s-1)</summary>
		public static Parameter TemperatureTendencyDueToParameterizations { get; } =
			new Parameter(ParameterCategory.Temperature, 26, "Temperature Tendency due to parameterizations", "K s-1");

		///<summary>Wet Bulb Temperature (K)</summary>
		public static Parameter WetBulbTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 27, "Wet Bulb Temperature", "K");

		///<summary>Unbalanced Component of Temperature (K)</summary>
		public static Parameter UnbalancedComponentOfTemperature { get; } =
			new Parameter(ParameterCategory.Temperature, 28, "Unbalanced Component of Temperature", "K");

		///<summary>Temperature Advection (K s-1)</summary>
		public static Parameter TemperatureAdvection { get; } =
			new Parameter(ParameterCategory.Temperature, 29, "Temperature Advection", "K s-1");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 1: Moisture

		///<summary>Specific humidity (kg kg-1)</summary>
		public static Parameter SpecificHumidity { get; } =
			new Parameter(ParameterCategory.Moisture, 0, "Specific humidity", "kg kg-1");

		///<summary>Relative humidity (%)</summary>
		public static Parameter RelativeHumidity { get; } = new Parameter(ParameterCategory.Moisture, 1, "Relative humidity", "%");

		///<summary>Humidity mixing ratio (kg kg-1)</summary>
		public static Parameter HumidityMixingRatio { get; } =
			new Parameter(ParameterCategory.Moisture, 2, "Humidity mixing ratio", "kg kg-1");

		///<summary>Precipitable water (kg m-2)</summary>
		public static Parameter PrecipitableWater { get; } =
			new Parameter(ParameterCategory.Moisture, 3, "Precipitable water", "kg m-2");

		///<summary>Vapor pressure (Pa)</summary>
		public static Parameter VaporPressure { get; } = new Parameter(ParameterCategory.Moisture, 4, "Vapor pressure", "Pa");

		///<summary>Saturation deficit (Pa)</summary>
		public static Parameter SaturationDeficit { get; } =
			new Parameter(ParameterCategory.Moisture, 5, "Saturation deficit", "Pa");

		///<summary>Evaporation (kg m-2)</summary>
		public static Parameter Evaporation { get; } = new Parameter(ParameterCategory.Moisture, 6, "Evaporation", "kg m-2");

		///<summary>Precipitation rate (kg m-2 s-1)</summary>
		public static Parameter PrecipitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 7, "Precipitation rate", "kg m-2 s-1");

		///<summary>Total precipitation (kg m-2)</summary>
		public static Parameter TotalPrecipitation { get; } =
			new Parameter(ParameterCategory.Moisture, 8, "Total precipitation", "kg m-2");

		///<summary>Large scale precipitation (non-convective) (kg m-2)</summary>
		public static Parameter LargeScalePrecipitationNonConvective { get; } = new Parameter(ParameterCategory.Moisture, 9,
			"Large scale precipitation (non-convective)", "kg m-2");

		///<summary>Convective precipitation (kg m-2)</summary>
		public static Parameter ConvectivePrecipitation { get; } =
			new Parameter(ParameterCategory.Moisture, 10, "Convective precipitation", "kg m-2");

		///<summary>Snow depth (m)</summary>
		public static Parameter SnowDepth { get; } = new Parameter(ParameterCategory.Moisture, 11, "Snow depth", "m");

		///<summary>Snowfall rate water equivalent (kg m-2 s-1)</summary>
		public static Parameter SnowfallRateWaterEquivalent { get; } =
			new Parameter(ParameterCategory.Moisture, 12, "Snowfall rate water equivalent", "kg m-2 s-1");

		///<summary>Water equivalent of accumulated snow depth (kg m-2)</summary>
		public static Parameter WaterEquivalentOfAccumulatedSnowDepth { get; } = new Parameter(ParameterCategory.Moisture, 13,
			"Water equivalent of accumulated snow depth", "kg m-2");

		///<summary>Convective snow (kg m-2)</summary>
		public static Parameter ConvectiveSnow { get; } =
			new Parameter(ParameterCategory.Moisture, 14, "Convective snow", "kg m-2");

		///<summary>Large scale snow (kg m-2)</summary>
		public static Parameter LargeScaleSnow { get; } =
			new Parameter(ParameterCategory.Moisture, 15, "Large scale snow", "kg m-2");

		///<summary>Snow melt (kg m-2)</summary>
		public static Parameter SnowMelt { get; } = new Parameter(ParameterCategory.Moisture, 16, "Snow melt", "kg m-2");

		///<summary>Snow age (day)</summary>
		public static Parameter SnowAge { get; } = new Parameter(ParameterCategory.Moisture, 17, "Snow age", "day");

		///<summary>Absolute humidity (kg m-3)</summary>
		public static Parameter AbsoluteHumidity { get; } =
			new Parameter(ParameterCategory.Moisture, 18, "Absolute humidity", "kg m-3");

		///<summary>Precipitation type (Code table (4.201))</summary>
		public static Parameter PrecipitationType { get; } =
			new Parameter(ParameterCategory.Moisture, 19, "Precipitation type", "Code table (4.201)");

		///<summary>Integrated liquid water (kg m-2)</summary>
		public static Parameter IntegratedLiquidWater { get; } =
			new Parameter(ParameterCategory.Moisture, 20, "Integrated liquid water", "kg m-2");

		///<summary>Condensate (kg kg-1)</summary>
		public static Parameter Condensate { get; } = new Parameter(ParameterCategory.Moisture, 21, "Condensate", "kg kg-1");

		///<summary>Cloud mixing ratio (kg kg-1)</summary>
		public static Parameter CloudMixingRatio { get; } =
			new Parameter(ParameterCategory.Moisture, 22, "Cloud mixing ratio", "kg kg-1");

		///<summary>Ice water mixing ratio (kg kg-1)</summary>
		public static Parameter IceWaterMixingRatio { get; } =
			new Parameter(ParameterCategory.Moisture, 23, "Ice water mixing ratio", "kg kg-1");

		///<summary>Rain mixing ratio (kg kg-1)</summary>
		public static Parameter RainMixingRatio { get; } =
			new Parameter(ParameterCategory.Moisture, 24, "Rain mixing ratio", "kg kg-1");

		///<summary>Snow mixing ratio (kg kg-1)</summary>
		public static Parameter SnowMixingRatio { get; } =
			new Parameter(ParameterCategory.Moisture, 25, "Snow mixing ratio", "kg kg-1");

		///<summary>Horizontal moisture convergence (kg kg-1 s-1)</summary>
		public static Parameter HorizontalMoistureConvergence { get; } = new Parameter(ParameterCategory.Moisture, 26,
			"Horizontal moisture convergence", "kg kg-1 s-1");

		///<summary>Maximum relative humidity (%)</summary>
		public static Parameter MaximumRelativeHumidity { get; } =
			new Parameter(ParameterCategory.Moisture, 27, "Maximum relative humidity", "%");

		///<summary>Maximum absolute humidity (kg m-3)</summary>
		public static Parameter MaximumAbsoluteHumidity { get; } =
			new Parameter(ParameterCategory.Moisture, 28, "Maximum absolute humidity", "kg m-3");

		///<summary>Total snowfall (m)</summary>
		public static Parameter TotalSnowfall { get; } = new Parameter(ParameterCategory.Moisture, 29, "Total snowfall", "m");

		///<summary>Precipitable water category (Code table (4.202))</summary>
		public static Parameter PrecipitableWaterCategory { get; } = new Parameter(ParameterCategory.Moisture, 30,
			"Precipitable water category", "Code table (4.202)");

		///<summary>Hail (m)</summary>
		public static Parameter Hail { get; } = new Parameter(ParameterCategory.Moisture, 31, "Hail", "m");

		///<summary>Graupel (snow pellets) (kg kg-1)</summary>
		public static Parameter Graupel { get; } =
			new Parameter(ParameterCategory.Moisture, 32, "Graupel (snow pellets)", "kg kg-1");

		///<summary>Categorical Rain (Code table 4.222)</summary>
		public static Parameter CategoricalRain { get; } =
			new Parameter(ParameterCategory.Moisture, 33, "Categorical Rain", "");

		///<summary>Categorical Freezing Rain (Code table 4.222)</summary>
		public static Parameter CategoricalFreezingRain { get; } =
			new Parameter(ParameterCategory.Moisture, 34, "Categorical Freezing Rain", "");

		///<summary>Categorical Ice Pellets (Code table 4.222)</summary>
		public static Parameter CategoricalIcePellets { get; } =
			new Parameter(ParameterCategory.Moisture, 35, "Categorical Ice Pellets", "");

		///<summary>Categorical Snow (Code table 4.222)</summary>
		public static Parameter CategoricalSnow { get; } =
			new Parameter(ParameterCategory.Moisture, 36, "Categorical Snow", "");

		///<summary>Convective Precipitation Rate (kg m-2 s-1)</summary>
		public static Parameter ConvectivePrecipitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 37, "Convective Precipitation Rate", "kg m-2 s-1");

		///<summary>Horizontal Moisture Divergence (kg kg-1 s-1)</summary>
		public static Parameter HorizontalMoistureDivergence { get; } =
			new Parameter(ParameterCategory.Moisture, 38, "Horizontal Moisture Divergence", "kg kg-1 s-1");

		///<summary>Percent frozen precipitation (%)</summary>
		public static Parameter PercentFrozenPrecipitation { get; } =
			new Parameter(ParameterCategory.Moisture, 39, "Percent frozen precipitation", "%");

		///<summary>Potential Evaporation (kg m-2)</summary>
		public static Parameter PotentialEvaporation { get; } =
			new Parameter(ParameterCategory.Moisture, 40, "Potential Evaporation", "kg m-2");

		///<summary>Potential Evaporation Rate (W m-2)</summary>
		public static Parameter PotentialEvaporationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 41, "Potential Evaporation Rate", "W m-2");

		///<summary>Snow Cover (%)</summary>
		public static Parameter SnowCover { get; } =
			new Parameter(ParameterCategory.Moisture, 42, "Snow Cover", "%");

		///<summary>Rain Fraction of Total Cloud Water (Proportion)</summary>
		public static Parameter RainFractionOfTotalCloudWater { get; } =
			new Parameter(ParameterCategory.Moisture, 43, "Rain Fraction of Total Cloud Water", "Proportion");

		///<summary>Rime Factor (Numeric)</summary>
		public static Parameter RimeFactor { get; } =
			new Parameter(ParameterCategory.Moisture, 44, "Rime Factor", "Numeric");

		///<summary>Total Column Integrated Rain (kg m-2)</summary>
		public static Parameter TotalColumnIntegratedRain { get; } =
			new Parameter(ParameterCategory.Moisture, 45, "Total Column Integrated Rain", "kg m-2");

		///<summary>Total Column Integrated Snow (kg m-2)</summary>
		public static Parameter TotalColumnIntegratedSnow { get; } =
			new Parameter(ParameterCategory.Moisture, 46, "Total Column Integrated Snow", "kg m-2");

		///<summary>Large Scale Water Precipitation (Non-Convective)  (kg m-2)</summary>
		public static Parameter LargeScaleWaterPrecipitation { get; } =
			new Parameter(ParameterCategory.Moisture, 47, "Large Scale Water Precipitation (Non-Convective) ", "kg m-2");

		///<summary>Convective Water Precipitation  (kg m-2)</summary>
		public static Parameter ConvectiveWaterPrecipitation { get; } =
			new Parameter(ParameterCategory.Moisture, 48, "Convective Water Precipitation ", "kg m-2");

		///<summary>Total Water Precipitation  (kg m-2)</summary>
		public static Parameter TotalWaterPrecipitation { get; } =
			new Parameter(ParameterCategory.Moisture, 49, "Total Water Precipitation ", "kg m-2");

		///<summary>Total Snow Precipitation  (kg m-2)</summary>
		public static Parameter TotalSnowPrecipitation { get; } =
			new Parameter(ParameterCategory.Moisture, 50, "Total Snow Precipitation ", "kg m-2");

		///<summary>Total Column Water(Vertically integrated total water (vapour+cloud water/ice) (kg m-2)</summary>
		public static Parameter TotalColumnWater { get; } =
			new Parameter(ParameterCategory.Moisture, 51, "Total Column Water(Vertically integrated total water (vapour+cloud water/ice)", "kg m-2");

		///<summary>Total Precipitation Rate  (kg m-2 s-1)</summary>
		public static Parameter TotalPrecipitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 52, "Total Precipitation Rate ", "kg m-2 s-1");

		///<summary>Total Snowfall Rate Water Equivalent  (kg m-2 s-1)</summary>
		public static Parameter TotalSnowfallRateWaterEquivalent { get; } =
			new Parameter(ParameterCategory.Moisture, 53, "Total Snowfall Rate Water Equivalent ", "kg m-2 s-1");

		///<summary>Large Scale Precipitation Rate (kg m-2 s-1)</summary>
		public static Parameter LargeScalePrecipitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 54, "Large Scale Precipitation Rate", "kg m-2 s-1");

		///<summary>Convective Snowfall Rate Water Equivalent (kg m-2 s-1)</summary>
		public static Parameter ConvectiveSnowfallRateWaterEquivalent { get; } =
			new Parameter(ParameterCategory.Moisture, 55, "Convective Snowfall Rate Water Equivalent", "kg m-2 s-1");

		///<summary>Large Scale Snowfall Rate Water Equivalent (kg m-2 s-1)</summary>
		public static Parameter LargeScaleSnowfallRateWaterEquivalent { get; } =
			new Parameter(ParameterCategory.Moisture, 56, "Large Scale Snowfall Rate Water Equivalent", "kg m-2 s-1");

		///<summary>Total Snowfall Rate (m s-1)</summary>
		public static Parameter TotalSnowfallRate { get; } =
			new Parameter(ParameterCategory.Moisture, 57, "Total Snowfall Rate", "m s-1");

		///<summary>Convective Snowfall Rate (m s-1)</summary>
		public static Parameter ConvectiveSnowfallRate { get; } =
			new Parameter(ParameterCategory.Moisture, 58, "Convective Snowfall Rate", "m s-1");

		///<summary>Large Scale Snowfall Rate (m s-1)</summary>
		public static Parameter LargeScaleSnowfallRate { get; } =
			new Parameter(ParameterCategory.Moisture, 59, "Large Scale Snowfall Rate", "m s-1");

		///<summary>Snow Depth Water Equivalent (kg m-2)</summary>
		public static Parameter SnowDepthWaterEquivalent { get; } =
			new Parameter(ParameterCategory.Moisture, 60, "Snow Depth Water Equivalent", "kg m-2");

		///<summary>Snow Density (kg m-3)</summary>
		public static Parameter SnowDensity { get; } =
			new Parameter(ParameterCategory.Moisture, 61, "Snow Density", "kg m-3");

		///<summary>Snow Evaporation (kg m-2)</summary>
		public static Parameter SnowEvaporation { get; } =
			new Parameter(ParameterCategory.Moisture, 62, "Snow Evaporation", "kg m-2");

		///<summary>Total Column Integrated Water Vapour (kg m-2)</summary>
		public static Parameter TotalColumnIntegratedWaterVapour { get; } =
			new Parameter(ParameterCategory.Moisture, 64, "Total Column Integrated Water Vapour", "kg m-2");

		///<summary>Rain Precipitation Rate (kg m-2 s-1)</summary>
		public static Parameter RainPrecipitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 65, "Rain Precipitation Rate", "kg m-2 s-1");

		///<summary>Snow Precipitation Rate (kg m-2 s-1)</summary>
		public static Parameter SnowPrecipitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 66, "Snow Precipitation Rate", "kg m-2 s-1");

		///<summary>Freezing Rain Precipitation Rate (kg m-2 s-1)</summary>
		public static Parameter FreezingRainPrecipitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 67, "Freezing Rain Precipitation Rate", "kg m-2 s-1");

		///<summary>Ice Pellets Precipitation Rate (kg m-2 s-1)</summary>
		public static Parameter IcePelletsPrecipitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 68, "Ice Pellets Precipitation Rate", "kg m-2 s-1");

		///<summary>Total Column Integrate Cloud Water (kg m-2)</summary>
		public static Parameter TotalColumnIntegrateCloudWater { get; } =
			new Parameter(ParameterCategory.Moisture, 69, "Total Column Integrate Cloud Water", "kg m-2");

		///<summary>Total Column Integrate Cloud Ice (kg m-2)</summary>
		public static Parameter TotalColumnIntegrateCloudIce { get; } =
			new Parameter(ParameterCategory.Moisture, 70, "Total Column Integrate Cloud Ice", "kg m-2");

		///<summary>Hail Mixing Ratio (kg kg-1)</summary>
		public static Parameter HailMixingRatio { get; } =
			new Parameter(ParameterCategory.Moisture, 71, "Hail Mixing Ratio", "kg kg-1");

		///<summary>Total Column Integrate Hail (kg m-2)</summary>
		public static Parameter TotalColumnIntegrateHail { get; } =
			new Parameter(ParameterCategory.Moisture, 72, "Total Column Integrate Hail", "kg m-2");

		///<summary>Hail Prepitation Rate (kg m-2 s-1)</summary>
		public static Parameter HailPrepitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 73, "Hail Prepitation Rate", "kg m-2 s-1");

		///<summary>Total Column Integrate Graupel (kg m-2)</summary>
		public static Parameter TotalColumnIntegrateGraupel { get; } =
			new Parameter(ParameterCategory.Moisture, 74, "Total Column Integrate Graupel", "kg m-2");

		///<summary>Graupel (Snow Pellets) Prepitation Rate (kg m-2 s-1)</summary>
		public static Parameter GraupelPrecipitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 75, "Graupel (Snow Pellets) Prepitation Rate", "kg m-2 s-1");

		///<summary>Convective Rain Rate (kg m-2 s-1)</summary>
		public static Parameter ConvectiveRainRate { get; } =
			new Parameter(ParameterCategory.Moisture, 76, "Convective Rain Rate", "kg m-2 s-1");

		///<summary>Large Scale Rain Rate (kg m-2 s-1)</summary>
		public static Parameter LargeScaleRainRate { get; } =
			new Parameter(ParameterCategory.Moisture, 77, "Large Scale Rain Rate", "kg m-2 s-1");

		///<summary>Total Column Integrate Water (Allcomponents including precipitation) (kg m-2)</summary>
		public static Parameter TotalColumnIntegrateWater { get; } =
			new Parameter(ParameterCategory.Moisture, 78, "Total Column Integrate Water (Allcomponents including precipitation)", "kg m-2");

		///<summary>Evaporation Rate (kg m-2 s-1)</summary>
		public static Parameter EvaporationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 79, "Evaporation Rate", "kg m-2 s-1");

		///<summary>Total Condensate (kg kg-1)</summary>
		public static Parameter TotalCondensate { get; } =
			new Parameter(ParameterCategory.Moisture, 80, "Total Condensate", "kg kg-1");

		///<summary>Total Column-Integrate Condensate (kg m-2)</summary>
		public static Parameter TotalColumnIntegrateCondensate { get; } =
			new Parameter(ParameterCategory.Moisture, 81, "Total Column-Integrate Condensate", "kg m-2");

		///<summary>Cloud Ice Mixing Ratio (kg kg-1)</summary>
		public static Parameter CloudIceMixingRatio { get; } =
			new Parameter(ParameterCategory.Moisture, 82, "Cloud Ice Mixing Ratio", "kg kg-1");

		///<summary>Specific Cloud Liquid Water Content (kg kg-1)</summary>
		public static Parameter SpecificCloudLiquidWaterContent { get; } =
			new Parameter(ParameterCategory.Moisture, 83, "Specific Cloud Liquid Water Content", "kg kg-1");

		///<summary>Specific Cloud Ice Water Content (kg kg-1)</summary>
		public static Parameter SpecificCloudIceWaterContent { get; } =
			new Parameter(ParameterCategory.Moisture, 84, "Specific Cloud Ice Water Content", "kg kg-1");

		///<summary>Specific Rain Water Content (kg kg-1)</summary>
		public static Parameter SpecificRainWaterContent { get; } =
			new Parameter(ParameterCategory.Moisture, 85, "Specific Rain Water Content", "kg kg-1");

		///<summary>Specific Snow Water Content (kg kg-1)</summary>
		public static Parameter SpecificSnowWaterContent { get; } =
			new Parameter(ParameterCategory.Moisture, 86, "Specific Snow Water Content", "kg kg-1");

		///<summary>Stratiform Precipitation Rate (kg m-2 s-1)</summary>
		public static Parameter StratiformPrecipitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 87, "Stratiform Precipitation Rate", "kg m-2 s-1");

		///<summary>Categorical Convective Precipitation (Code table 4.222)</summary>
		public static Parameter CategoricalConvectivePrecipitation { get; } =
			new Parameter(ParameterCategory.Moisture, 88, "Categorical Convective Precipitation", "");

		///<summary>Total Kinematic Moisture Flux (kg kg-1 m s-1)</summary>
		public static Parameter TotalKinematicMoistureFlux { get; } =
			new Parameter(ParameterCategory.Moisture, 90, "Total Kinematic Moisture Flux", "kg kg-1 m s-1");

		///<summary>U-component (zonal) Kinematic Moisture Flux (kg kg-1 m s-1)</summary>
		public static Parameter Ucomponent { get; } =
			new Parameter(ParameterCategory.Moisture, 91, "U-component (zonal) Kinematic Moisture Flux", "kg kg-1 m s-1");

		///<summary>V-component (meridional) Kinematic Moisture Flux (kg kg-1 m s-1)</summary>
		public static Parameter Vcomponent { get; } =
			new Parameter(ParameterCategory.Moisture, 92, "V-component (meridional) Kinematic Moisture Flux", "kg kg-1 m s-1");

		///<summary>Relative Humidity With Respect to Water (%)</summary>
		public static Parameter RelativeHumidityWithRespectToWater { get; } =
			new Parameter(ParameterCategory.Moisture, 93, "Relative Humidity With Respect to Water", "%");

		///<summary>Relative Humidity With Respect to Ice (%)</summary>
		public static Parameter RelativeHumidityWithRespectToIce { get; } =
			new Parameter(ParameterCategory.Moisture, 94, "Relative Humidity With Respect to Ice", "%");

		///<summary>Freezing or Frozen Precipitation Rate (kg m-2 s-1)</summary>
		public static Parameter FreezingOrFrozenPrecipitationRate { get; } =
			new Parameter(ParameterCategory.Moisture, 95, "Freezing or Frozen Precipitation Rate", "kg m-2 s-1");

		///<summary>Mass Density of Rain (kg m-3)</summary>
		public static Parameter MassDensityOfRain { get; } =
			new Parameter(ParameterCategory.Moisture, 96, "Mass Density of Rain", "kg m-3");

		///<summary>Mass Density of Snow (kg m-3)</summary>
		public static Parameter MassDensityOfSnow { get; } =
			new Parameter(ParameterCategory.Moisture, 97, "Mass Density of Snow", "kg m-3");

		///<summary>Mass Density of Graupel (kg m-3)</summary>
		public static Parameter MassDensityOfGraupel { get; } =
			new Parameter(ParameterCategory.Moisture, 98, "Mass Density of Graupel", "kg m-3");

		///<summary>Mass Density of Hail (kg m-3)</summary>
		public static Parameter MassDensityOfHail { get; } =
			new Parameter(ParameterCategory.Moisture, 99, "Mass Density of Hail", "kg m-3");

		///<summary>Specific Number Concentration of Rain (kg-1)</summary>
		public static Parameter SpecificNumberConcentrationOfRain { get; } =
			new Parameter(ParameterCategory.Moisture, 100, "Specific Number Concentration of Rain", "kg-1");

		///<summary>Specific Number Concentration of Snow (kg-1)</summary>
		public static Parameter SpecificNumberConcentrationOfSnow { get; } =
			new Parameter(ParameterCategory.Moisture, 101, "Specific Number Concentration of Snow", "kg-1");

		///<summary>Specific Number Concentration of Graupel (kg-1)</summary>
		public static Parameter SpecificNumberConcentrationOfGraupel { get; } =
			new Parameter(ParameterCategory.Moisture, 102, "Specific Number Concentration of Graupel", "kg-1");

		///<summary>Specific Number Concentration of Hail (kg-1)</summary>
		public static Parameter SpecificNumberConcentrationOfHail { get; } =
			new Parameter(ParameterCategory.Moisture, 103, "Specific Number Concentration of Hail", "kg-1");

		///<summary>Number Density of Rain (m-3)</summary>
		public static Parameter NumberDensityOfRain { get; } =
			new Parameter(ParameterCategory.Moisture, 104, "Number Density of Rain", "m-3");

		///<summary>Number Density of Snow (m-3)</summary>
		public static Parameter NumberDensityOfSnow { get; } =
			new Parameter(ParameterCategory.Moisture, 105, "Number Density of Snow", "m-3");

		///<summary>Number Density of Graupel (m-3)</summary>
		public static Parameter NumberDensityOfGraupel { get; } =
			new Parameter(ParameterCategory.Moisture, 106, "Number Density of Graupel", "m-3");

		///<summary>Number Density of Hail (m-3)</summary>
		public static Parameter NumberDensityOfHail { get; } =
			new Parameter(ParameterCategory.Moisture, 107, "Number Density of Hail", "m-3");

		///<summary>Specific Humidity Tendency due to Parameterizations (kg kg-1 s-1)</summary>
		public static Parameter SpecificHumidityTendencyDueToParameterizations { get; } =
			new Parameter(ParameterCategory.Moisture, 108, "Specific Humidity Tendency due to Parameterizations", "kg kg-1 s-1");

		///<summary>Mass Density of Liquid Water Coating on Hail Expressed as Mass of Liquid Water per Unit Volume of Air (kg m-3)</summary>
		public static Parameter MassDensityOfLiquidWaterCoatingOnHail { get; } =
			new Parameter(ParameterCategory.Moisture, 109, "Mass Density of Liquid Water Coating on Hail Expressed as Mass of Liquid Water per Unit Volume of Air", "kg m-3");

		///<summary>Specific Mass of Liquid Water Coating on HailExpressed as Mass of Liquid Water per Unit Mass of Moist Air (kg kg-1)</summary>
		public static Parameter SpecificMassOfLiquidWaterCoatingOnHail { get; } =
			new Parameter(ParameterCategory.Moisture, 110, "Specific Mass of Liquid Water Coating on HailExpressed as Mass of Liquid Water per Unit Mass of Moist Air", "kg kg-1");

		///<summary>Mass Mixing Ratio of Liquid Water Coating on Hail Expressed as Mass of Liquid Water per Unit Mass of Dry Air (kg kg-1)</summary>
		public static Parameter MassMixingRatioOfLiquidWaterCoatingOnHail { get; } =
			new Parameter(ParameterCategory.Moisture, 111, "Mass Mixing Ratio of Liquid Water Coating on Hail Expressed as Mass of Liquid Water per Unit Mass of Dry Air", "kg kg-1");

		///<summary>Mass Density of Liquid Water Coating on GraupelExpressed as Mass of Liquid Water per Unit Volume of Air (kg m-3)</summary>
		public static Parameter MassDensityOfLiquidWaterCoatingOnGraupel { get; } =
			new Parameter(ParameterCategory.Moisture, 112, "Mass Density of Liquid Water Coating on GraupelExpressed as Mass of Liquid Water per Unit Volume of Air", "kg m-3");

		///<summary>Specific Mass of Liquid Water Coating on Graupel Expressed as Mass of Liquid Water per Unit Mass of Moist Air (kg kg-1)</summary>
		public static Parameter SpecificMassOfLiquidWaterCoatingOnGraupel { get; } =
			new Parameter(ParameterCategory.Moisture, 113, "Specific Mass of Liquid Water Coating on Graupel Expressed as Mass of Liquid Water per Unit Mass of Moist Air", "kg kg-1");

		///<summary>Mass Mixing Ratio of Liquid Water Coating on Graupel Expressed as Mass of Liquid Water per Unit Mass of Dry Air (kg kg-1)</summary>
		public static Parameter MassMixingRatioOfLiquidWaterCoatingOnGraupel { get; } =
			new Parameter(ParameterCategory.Moisture, 114, "Mass Mixing Ratio of Liquid Water Coating on Graupel Expressed as Mass of Liquid Water per Unit Mass of Dry Air", "kg kg-1");

		///<summary>Mass Density of Liquid Water Coating on Snow Expressed as Mass of Liquid Water per Unit Volume of Air (kg m-3)</summary>
		public static Parameter MassDensityOfLiquidWaterCoatingOnSnow { get; } =
			new Parameter(ParameterCategory.Moisture, 115, "Mass Density of Liquid Water Coating on Snow Expressed as Mass of Liquid Water per Unit Volume of Air", "kg m-3");

		///<summary>Specific Mass of Liquid Water Coating on Snow Expressed as Mass of Liquid Water per Unit Mass of Moist Air (kg kg-1)</summary>
		public static Parameter SpecificMassOfLiquidWaterCoatingOnSnow { get; } =
			new Parameter(ParameterCategory.Moisture, 116, "Specific Mass of Liquid Water Coating on Snow Expressed as Mass of Liquid Water per Unit Mass of Moist Air", "kg kg-1");

		///<summary>Mass Mixing Ratio of Liquid Water Coating on Snow Expressed as Mass of Liquid Water per Unit Mass of Dry Air (kg kg-1)</summary>
		public static Parameter MassMixingRatioOfLiquidWaterCoatingOnSnow { get; } =
			new Parameter(ParameterCategory.Moisture, 117, "Mass Mixing Ratio of Liquid Water Coating on Snow Expressed as Mass of Liquid Water per Unit Mass of Dry Air", "kg kg-1");

		///<summary>Unbalanced Component of Specific Humidity (kg kg-1)</summary>
		public static Parameter UnbalancedComponentOfSpecificHumidity { get; } =
			new Parameter(ParameterCategory.Moisture, 118, "Unbalanced Component of Specific Humidity", "kg kg-1");

		///<summary>Unbalanced Component of Specific Cloud Liquid Water content (kg kg-1)</summary>
		public static Parameter UnbalancedComponentOfSpecificCloudLiquidWaterContent { get; } =
			new Parameter(ParameterCategory.Moisture, 119, "Unbalanced Component of Specific Cloud Liquid Water content", "kg kg-1");

		///<summary>Unbalanced Component of Specific Cloud Ice Water content (kg kg-1)</summary>
		public static Parameter UnbalancedComponentOfSpecificCloudIceWaterContent { get; } =
			new Parameter(ParameterCategory.Moisture, 120, "Unbalanced Component of Specific Cloud Ice Water content", "kg kg-1");

		///<summary>Fraction of Snow Cover (Proportion)</summary>
		public static Parameter FractionOfSnowCover { get; } =
			new Parameter(ParameterCategory.Moisture, 121, "Fraction of Snow Cover", "Proportion");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 2: Momentum

		///<summary>Wind direction (from which blowing) (deg true)</summary>
		public static Parameter WindDirection { get; } =
			new Parameter(ParameterCategory.Momentum, 0, "Wind direction (from which blowing)", "deg true");

		///<summary>Wind speed (m s-1)</summary>
		public static Parameter WindSpeed { get; } = new Parameter(ParameterCategory.Momentum, 1, "Wind speed", "m s-1");

		///<summary>u-component of wind (m s-1)</summary>
		public static Parameter UComponentOfWind { get; } =
			new Parameter(ParameterCategory.Momentum, 2, "u-component of wind", "m s-1");

		///<summary>v-component of wind (m s-1)</summary>
		public static Parameter VComponentOfWind { get; } =
			new Parameter(ParameterCategory.Momentum, 3, "v-component of wind", "m s-1");

		///<summary>Stream function (m2 s-1)</summary>
		public static Parameter StreamFunction { get; } =
			new Parameter(ParameterCategory.Momentum, 4, "Stream function", "m2 s-1");

		///<summary>Velocity potential (m2 s-1)</summary>
		public static Parameter VelocityPotential { get; } =
			new Parameter(ParameterCategory.Momentum, 5, "Velocity potential", "m2 s-1");

		///<summary>Montgomery stream function (m2 s-2)</summary>
		public static Parameter MontgomeryStreamFunction { get; } =
			new Parameter(ParameterCategory.Momentum, 6, "Montgomery stream function", "m2 s-2");

		///<summary>Sigma coordinate vertical velocity (s-1)</summary>
		public static Parameter SigmaCoordinateVerticalVelocity { get; } =
			new Parameter(ParameterCategory.Momentum, 7, "Sigma coordinate vertical velocity", "s-1");

		///<summary>Vertical velocity (pressure) (Pa s-1)</summary>
		public static Parameter VerticalVelocityPressure { get; } =
			new Parameter(ParameterCategory.Momentum, 8, "Vertical velocity (pressure)", "Pa s-1");

		///<summary>Vertical velocity (geometric) (m s-1)</summary>
		public static Parameter VerticalVelocityGeometric { get; } =
			new Parameter(ParameterCategory.Momentum, 9, "Vertical velocity (geometric)", "m s-1");

		///<summary>Absolute vorticity (s-1)</summary>
		public static Parameter AbsoluteVorticity { get; } =
			new Parameter(ParameterCategory.Momentum, 10, "Absolute vorticity", "s-1");

		///<summary>Absolute divergence (s-1)</summary>
		public static Parameter AbsoluteDivergence { get; } =
			new Parameter(ParameterCategory.Momentum, 11, "Absolute divergence", "s-1");

		///<summary>Relative vorticity (s-1)</summary>
		public static Parameter RelativeVorticity { get; } =
			new Parameter(ParameterCategory.Momentum, 12, "Relative vorticity", "s-1");

		///<summary>Relative divergence (s-1)</summary>
		public static Parameter RelativeDivergence { get; } =
			new Parameter(ParameterCategory.Momentum, 13, "Relative divergence", "s-1");

		///<summary>Potential vorticity (K m2 kg-1 s-1)</summary>
		public static Parameter PotentialVorticity { get; } =
			new Parameter(ParameterCategory.Momentum, 14, "Potential vorticity", "K m2 kg-1 s-1");

		///<summary>Vertical u-component shear (s-1)</summary>
		public static Parameter VerticalUComponentShear { get; } =
			new Parameter(ParameterCategory.Momentum, 15, "Vertical u-component shear", "s-1");

		///<summary>Vertical v-component shear (s-1)</summary>
		public static Parameter VerticalVComponentShear { get; } =
			new Parameter(ParameterCategory.Momentum, 16, "Vertical v-component shear", "s-1");

		///<summary>Momentum flux, u component (s-1)</summary>
		public static Parameter MomentumFluxUComponent { get; } =
			new Parameter(ParameterCategory.Momentum, 17, "Momentum flux, u component", "s-1");

		///<summary>Momentum flux, v component (s-1)</summary>
		public static Parameter MomentumFluxVComponent { get; } =
			new Parameter(ParameterCategory.Momentum, 18, "Momentum flux, v component", "s-1");

		///<summary>Wind mixing energy (J)</summary>
		public static Parameter WindMixingEnergy { get; } =
			new Parameter(ParameterCategory.Momentum, 19, "Wind mixing energy", "J");

		///<summary>Boundary layer dissipation (W m-2)</summary>
		public static Parameter BoundaryLayerDissipation { get; } =
			new Parameter(ParameterCategory.Momentum, 20, "Boundary layer dissipation", "W m-2");

		///<summary>Maximum wind speed (m s-1)</summary>
		public static Parameter MaximumWindSpeed { get; } =
			new Parameter(ParameterCategory.Momentum, 21, "Maximum wind speed", "m s-1");

		///<summary>Wind speed (gust) (m s-1)</summary>
		public static Parameter WindSpeedGust { get; } =
			new Parameter(ParameterCategory.Momentum, 22, "Wind speed (gust)", "m s-1");

		///<summary>u-component of wind (gust) (m s-1)</summary>
		public static Parameter UComponentOfWindGust { get; } =
			new Parameter(ParameterCategory.Momentum, 23, "u-component of wind (gust)", "m s-1");

		///<summary>v-component of wind (gust) (m s-1)</summary>
		public static Parameter VComponentOfWindGust { get; } =
			new Parameter(ParameterCategory.Momentum, 24, "v-component of wind (gust)", "m s-1");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 3: Mass

		///<summary>Pressure (Pa)</summary>
		public static Parameter Pressure { get; } = new Parameter(ParameterCategory.Mass, 0, "Pressure", "Pa");

		///<summary>Pressure reduced to MSL (Pa)</summary>
		public static Parameter PressureReducedToMsl { get; } =
			new Parameter(ParameterCategory.Mass, 1, "Pressure reduced to MSL", "Pa");

		///<summary>Pressure tendency (Pa s-1)</summary>
		public static Parameter PressureTendency { get; } =
			new Parameter(ParameterCategory.Mass, 2, "Pressure tendency", "Pa s-1");

		///<summary>ICAO Standard Atmosphere Reference Height (m)</summary>
		public static Parameter IcaoStandardAtmosphereReferenceHeight { get; } =
			new Parameter(ParameterCategory.Mass, 3, "ICAO Standard Atmosphere Reference Height", "m");

		///<summary>Geopotential (m2 s-2)</summary>
		public static Parameter Geopotential { get; } = new Parameter(ParameterCategory.Mass, 4, "Geopotential", "m2 s-2");

		///<summary>Geopotential height (gpm)</summary>
		public static Parameter GeopotentialHeight { get; } =
			new Parameter(ParameterCategory.Mass, 5, "Geopotential height", "gpm");

		///<summary>Geometric height (m)</summary>
		public static Parameter GeometricHeight { get; } = new Parameter(ParameterCategory.Mass, 6, "Geometric height", "m");

		///<summary>Standard deviation of height (m)</summary>
		public static Parameter StandardDeviationOfHeight { get; } =
			new Parameter(ParameterCategory.Mass, 7, "Standard deviation of height", "m");

		///<summary>Pressure anomaly (Pa)</summary>
		public static Parameter PressureAnomaly { get; } = new Parameter(ParameterCategory.Mass, 8, "Pressure anomaly", "Pa");

		///<summary>Geopotential height anomaly (gpm)</summary>
		public static Parameter GeopotentialHeightAnomaly { get; } =
			new Parameter(ParameterCategory.Mass, 9, "Geopotential height anomaly", "gpm");

		///<summary>Density (kg m-3)</summary>
		public static Parameter Density { get; } = new Parameter(ParameterCategory.Mass, 10, "Density", "kg m-3");

		///<summary>Altimeter setting (Pa)</summary>
		public static Parameter AltimeterSetting { get; } = new Parameter(ParameterCategory.Mass, 11, "Altimeter setting", "Pa");

		///<summary>Thickness (m)</summary>
		public static Parameter Thickness { get; } = new Parameter(ParameterCategory.Mass, 12, "Thickness", "m");

		///<summary>Pressure altitude (m)</summary>
		public static Parameter PressureAltitude { get; } = new Parameter(ParameterCategory.Mass, 13, "Pressure altitude", "m");

		///<summary>Density altitude (m)</summary>
		public static Parameter DensityAltitude { get; } = new Parameter(ParameterCategory.Mass, 14, "Density altitude", "m");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 4: Short-wave Radiation

		///<summary>Net short-wave radiation flux (surface) (W m-2)</summary>
		public static Parameter NetShortWaveRadiationFluxSurface { get; } = new Parameter(ParameterCategory.ShortWaveRadiation, 0,
			"Net short-wave radiation flux (surface)", "W m-2");

		///<summary>Net short-wave radiation flux (top of atmosphere) (W m-2)</summary>
		public static Parameter NetShortWaveRadiationFlux { get; } = new Parameter(ParameterCategory.ShortWaveRadiation, 1,
			"Net short-wave radiation flux (top of atmosphere)", "W m-2");

		///<summary>Short wave radiation flux (W m-2)</summary>
		public static Parameter ShortWaveRadiationFlux { get; } =
			new Parameter(ParameterCategory.ShortWaveRadiation, 2, "Short wave radiation flux", "W m-2");

		///<summary>Global radiation flux (W m-2)</summary>
		public static Parameter GlobalRadiationFlux { get; } =
			new Parameter(ParameterCategory.ShortWaveRadiation, 3, "Global radiation flux", "W m-2");

		///<summary>Brightness temperature (K)</summary>
		public static Parameter BrightnessTemperature { get; } =
			new Parameter(ParameterCategory.ShortWaveRadiation, 4, "Brightness temperature", "K");

		///<summary>Radiance (with respect to wave number) (W m-1 sr-1)</summary>
		public static Parameter RadianceWaveNumber { get; } = new Parameter(ParameterCategory.ShortWaveRadiation, 5,
			"Radiance (with respect to wave number)", "W m-1 sr-1");

		///<summary>Radiance (with respect to wave length) (W m-3 sr-1)</summary>
		public static Parameter RadianceWaveLength { get; } = new Parameter(ParameterCategory.ShortWaveRadiation, 6,
			"Radiance (with respect to wave length)", "W m-3 sr-1");

		///<summary>Surface short-wave (solar) radiation downwards (J m-2)</summary>
		public static Parameter SurfaceShortWaveRadiationDownwards { get; } = new Parameter(ParameterCategory.ShortWaveRadiation, 7,
			"Surface short-wave (solar) radiation downwards", "J m-2");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 5: Long-wave Radiation

		///<summary>Net long wave radiation flux (surface) (W m-2)</summary>
		public static Parameter NetLongWaveRadiationFluxSurface { get; } = new Parameter(ParameterCategory.LongWaveRadiation, 0,
			"Net long wave radiation flux (surface)", "W m-2");

		///<summary>Net long wave radiation flux (top of atmosphere) (W m-2)</summary>
		public static Parameter NetLongWaveRadiationFlux { get; } = new Parameter(ParameterCategory.LongWaveRadiation, 1,
			"Net long wave radiation flux (top of atmosphere)", "W m-2");

		///<summary>Long wave radiation flux (W m-2)</summary>
		public static Parameter LongWaveRadiationFlux { get; } =
			new Parameter(ParameterCategory.LongWaveRadiation, 2, "Long wave radiation flux", "W m-2");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 6: Cloud

		///<summary>Cloud Ice (kg m-2)</summary>
		public static Parameter CloudIce { get; } = new Parameter(ParameterCategory.Cloud, 0, "Cloud Ice", "kg m-2");

		///<summary>Total cloud cover (%)</summary>
		public static Parameter TotalCloudCover { get; } = new Parameter(ParameterCategory.Cloud, 1, "Total cloud cover", "%");

		///<summary>Convective cloud cover (%)</summary>
		public static Parameter ConvectiveCloudCover { get; } =
			new Parameter(ParameterCategory.Cloud, 2, "Convective cloud cover", "%");

		///<summary>Low cloud cover (%)</summary>
		public static Parameter LowCloudCover { get; } = new Parameter(ParameterCategory.Cloud, 3, "Low cloud cover", "%");

		///<summary>Medium cloud cover (%)</summary>
		public static Parameter MediumCloudCover { get; } = new Parameter(ParameterCategory.Cloud, 4, "Medium cloud cover", "%");

		///<summary>High cloud cover (%)</summary>
		public static Parameter HighCloudCover { get; } = new Parameter(ParameterCategory.Cloud, 5, "High cloud cover", "%");

		///<summary>Cloud water (kg m-2)</summary>
		public static Parameter CloudWater { get; } = new Parameter(ParameterCategory.Cloud, 6, "Cloud water", "kg m-2");

		///<summary>Cloud amount (%)</summary>
		public static Parameter CloudAmount { get; } = new Parameter(ParameterCategory.Cloud, 7, "Cloud amount", "%");

		///<summary>Cloud type (Code table (4.203))</summary>
		public static Parameter CloudType { get; } = new Parameter(ParameterCategory.Cloud, 8, "Cloud type", "Code table (4.203)");

		///<summary>Thunderstorm maximum tops (m)</summary>
		public static Parameter ThunderstormMaximumTops { get; } =
			new Parameter(ParameterCategory.Cloud, 9, "Thunderstorm maximum tops", "m");

		///<summary>Thunderstorm coverage (Code table (4.204))</summary>
		public static Parameter ThunderstormCoverage { get; } =
			new Parameter(ParameterCategory.Cloud, 10, "Thunderstorm coverage", "Code table (4.204)");

		///<summary>Cloud base (m)</summary>
		public static Parameter CloudBase { get; } = new Parameter(ParameterCategory.Cloud, 11, "Cloud base", "m");

		///<summary>Cloud top (m)</summary>
		public static Parameter CloudTop { get; } = new Parameter(ParameterCategory.Cloud, 12, "Cloud top", "m");

		///<summary>Ceiling (m)</summary>
		public static Parameter Ceiling { get; } = new Parameter(ParameterCategory.Cloud, 13, "Ceiling", "m");

		///<summary>Non-Convective Cloud Cover (%)</summary>
		public static Parameter NonConvectiveCloudCover { get; } = new Parameter(ParameterCategory.Cloud, 14, "Non-Convective Cloud Cover", "%");

		///<summary>Cloud Work Function (J kg-1)</summary>
		public static Parameter CloudWorkFunction { get; } = new Parameter(ParameterCategory.Cloud, 15, "Cloud Work Function", "J kg-1");

		///<summary>Convective Cloud Efficiency (Proportion)</summary>
		public static Parameter ConvectiveCloudEfficiency { get; } = new Parameter(ParameterCategory.Cloud, 16, "Convective Cloud Efficiency", "Proportion");

		///<summary>Ice fraction of total condensate (Proportion)</summary>
		public static Parameter IceFractionOfTotalCondensate { get; } = new Parameter(ParameterCategory.Cloud, 21, "Ice fraction of total condensate", "Proportion");

		///<summary>Cloud Cover (%)</summary>
		public static Parameter CloudCover { get; } = new Parameter(ParameterCategory.Cloud, 22, "Cloud Cover", "%");

		///<summary>Sunshine (Numeric)</summary>
		public static Parameter Sunshine { get; } = new Parameter(ParameterCategory.Cloud, 24, "Sunshine", "Numeric");

		///<summary>Horizontal Extent of Cumulonimbus (CB) (%)</summary>
		public static Parameter HorizontalExtentOfCumulonimbus { get; } = new Parameter(ParameterCategory.Cloud, 25, "Horizontal Extent of Cumulonimbus (CB)", "%");

		///<summary>Height of Convective Cloud Base (m)</summary>
		public static Parameter HeightOfConvectiveCloudBase { get; } = new Parameter(ParameterCategory.Cloud, 26, "Height of Convective Cloud Base", "m");

		///<summary>Height of Convective Cloud Top (m)</summary>
		public static Parameter HeightOfConvectiveCloudTop { get; } = new Parameter(ParameterCategory.Cloud, 27, "Height of Convective Cloud Top", "m");

		///<summary>Number Concentration of Cloud Droplets (kg-1)</summary>
		public static Parameter NumberConcentrationOfCloudDroplets { get; } = new Parameter(ParameterCategory.Cloud, 28, "Number Concentration of Cloud Droplets", "kg-1");

		///<summary>Number Concentration of Cloud Ice (kg-1)</summary>
		public static Parameter NumberConcentrationOfCloudIce { get; } = new Parameter(ParameterCategory.Cloud, 29, "Number Concentration of Cloud Ice", "kg-1");

		///<summary>Number Density of Cloud Droplets (m-3)</summary>
		public static Parameter NumberDensityOfCloudDroplets { get; } = new Parameter(ParameterCategory.Cloud, 30, "Number Density of Cloud Droplets", "m-3");

		///<summary>Number Density of Cloud Ice (m-3)</summary>
		public static Parameter NumberDensityOfCloudIce { get; } = new Parameter(ParameterCategory.Cloud, 31, "Number Density of Cloud Ice", "m-3");

		///<summary>Fraction of Cloud Cover (Numeric)</summary>
		public static Parameter FractionOfCloudCover { get; } = new Parameter(ParameterCategory.Cloud, 32, "Fraction of Cloud Cover", "Numeric");

		///<summary>Sunshine Duration (s)</summary>
		public static Parameter SunshineDuration { get; } = new Parameter(ParameterCategory.Cloud, 33, "Sunshine Duration", "s");

		///<summary>Surface Long Wave Effective Total Cloudiness (Numeric)</summary>
		public static Parameter SurfaceLongWaveEffectiveTotalCloudiness { get; } = new Parameter(ParameterCategory.Cloud, 34, "Surface Long Wave Effective Total Cloudiness", "Numeric");

		///<summary>Surface Short Wave Effective Total Cloudiness (Numeric)</summary>
		public static Parameter SurfaceShortWaveEffectiveTotalCloudiness { get; } = new Parameter(ParameterCategory.Cloud, 35, "Surface Short Wave Effective Total Cloudiness", "Numeric");

		///<summary>Fraction of Stratiform Precipitation Cover (Proportion)</summary>
		public static Parameter FractionOfStratiformPrecipitationCover { get; } = new Parameter(ParameterCategory.Cloud, 36, "Fraction of Stratiform Precipitation Cover", "Proportion");

		///<summary>Fraction of Convective Precipitation Cover (Proportion)</summary>
		public static Parameter FractionOfConvectivePrecipitationCover { get; } = new Parameter(ParameterCategory.Cloud, 37, "Fraction of Convective Precipitation Cover", "Proportion");

		///<summary>Mass Density of Cloud Droplets (kg m-3)</summary>
		public static Parameter MassDensityOfCloudDroplets { get; } = new Parameter(ParameterCategory.Cloud, 38, "Mass Density of Cloud Droplets", "kg m-3");

		///<summary>Mass Density of Cloud Ice (kg m-3)</summary>
		public static Parameter MassDensityOfCloudIce { get; } = new Parameter(ParameterCategory.Cloud, 39, "Mass Density of Cloud Ice", "kg m-3");

		///<summary>Mass Density of Convective Cloud Water Droplets (kg m-3)</summary>
		public static Parameter MassDensityOfConvectiveCloudWaterDroplets { get; } = new Parameter(ParameterCategory.Cloud, 40, "Mass Density of Convective Cloud Water Droplets", "kg m-3");

		///<summary>Volume Fraction of Cloud Water Droplets (Numeric)</summary>
		public static Parameter VolumeFractionOfCloudWaterDroplets { get; } = new Parameter(ParameterCategory.Cloud, 47, "Volume Fraction of Cloud Water Droplets", "Numeric");

		///<summary>Volume Fraction of Cloud Ice Particles (Numeric)</summary>
		public static Parameter VolumeFractionOfCloudIceParticles { get; } = new Parameter(ParameterCategory.Cloud, 48, "Volume Fraction of Cloud Ice Particles", "Numeric");

		///<summary>Volume Fraction of Cloud (Ice and/or Water) (Numeric)</summary>
		public static Parameter VolumeFractionOfCloud_IceAndOrWater { get; } = new Parameter(ParameterCategory.Cloud, 49, "Volume Fraction of Cloud (Ice and/or Water)", "Numeric");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 7: Thermodynamic Stability Indices

		///<summary>Parcel lifted index (to 500 hPa) (K)</summary>
		public static Parameter ParcelLiftedIndex { get; } = new Parameter(ParameterCategory.ThermodynamicStabilityIndices, 0,
			"Parcel lifted index (to 500 hPa)", "K");

		///<summary>Best lifted index (to 500 hPa) (K)</summary>
		public static Parameter BestLiftedIndex { get; } = new Parameter(ParameterCategory.ThermodynamicStabilityIndices, 1,
			"Best lifted index (to 500 hPa)", "K");

		///<summary>K index (K)</summary>
		public static Parameter KIndex { get; } =
			new Parameter(ParameterCategory.ThermodynamicStabilityIndices, 2, "K index", "K");

		///<summary>KO index (K)</summary>
		public static Parameter KoIndex { get; } =
			new Parameter(ParameterCategory.ThermodynamicStabilityIndices, 3, "KO index", "K");

		///<summary>Total totals index (K)</summary>
		public static Parameter TotalTotalsIndex { get; } =
			new Parameter(ParameterCategory.ThermodynamicStabilityIndices, 4, "Total totals index", "K");

		///<summary>Sweat index (numeric)</summary>
		public static Parameter SweatIndex { get; } =
			new Parameter(ParameterCategory.ThermodynamicStabilityIndices, 5, "Sweat index", "numeric");

		///<summary>Convective available potential energy (J kg-1)</summary>
		public static Parameter ConvectiveAvailablePotentialEnergy { get; } = new Parameter(
			ParameterCategory.ThermodynamicStabilityIndices, 6, "Convective available potential energy", "J kg-1");

		///<summary>Convective inhibition (J kg-1)</summary>
		public static Parameter ConvectiveInhibition { get; } = new Parameter(ParameterCategory.ThermodynamicStabilityIndices, 7,
			"Convective inhibition", "J kg-1");

		///<summary>Storm relative helicity (J kg-1)</summary>
		public static Parameter StormRelativeHelicity { get; } = new Parameter(ParameterCategory.ThermodynamicStabilityIndices, 8,
			"Storm relative helicity", "J kg-1");

		///<summary>Energy helicity index (numeric)</summary>
		public static Parameter EnergyHelicityIndex { get; } = new Parameter(ParameterCategory.ThermodynamicStabilityIndices, 9,
			"Energy helicity index", "numeric");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 13: Aerosols

		///<summary>Aerosol type (Code table (4.205))</summary>
		public static Parameter AerosolType { get; } =
			new Parameter(ParameterCategory.Aerosols, 0, "Aerosol type", "Code table (4.205)");

		///<summary>Particulate matter (coarse)</summary>
		public static Parameter ParticulateMatterCourse { get; } =
			new Parameter(ParameterCategory.Aerosols, 192, "Particulate matter (coarse)", "µg m-3");

		///<summary>Particulate matter (fine)</summary>
		public static Parameter ParticulateMatterFine { get; } =
			new Parameter(ParameterCategory.Aerosols, 193, "Particulate matter (fine)", "µg m-3");

		///<summary>Particulate matter (fine) log</summary>
		public static Parameter ParticulateMatterFineLog { get; } =
			new Parameter(ParameterCategory.Aerosols, 194, "Particulate matter (fine) log", "log10(µg m-3)");

		///<summary>Particulate matter (coarse)</summary>
		public static Parameter IntegratedColumnParticularMatterFine { get; } =
			new Parameter(ParameterCategory.Aerosols, 195, "Integrated column particulate matter (fine)", "log10(µg m-3)");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 14: Trace Gases

		///<summary>Total ozone (Dobson)</summary>
		public static Parameter TotalOzone { get; } = new Parameter(ParameterCategory.TraceGases, 0, "Total ozone", "Dobson");

		#endregion

		#region Product Discipline 0 - Meteorological products, Parameter Category 15: Radar

		///<summary>Base spectrum width (m s-1)</summary>
		public static Parameter BaseSpectrumWidth { get; } =
			new Parameter(ParameterCategory.Radar, 0, "Base spectrum width", "m s-1");

		///<summary>Base reflectivity (dB)</summary>
		public static Parameter BaseReflectivity { get; } = new Parameter(ParameterCategory.Radar, 1, "Base reflectivity", "dB");

		///<summary>Base radial velocity (m s-1)</summary>
		public static Parameter BaseRadialVelocity { get; } =
			new Parameter(ParameterCategory.Radar, 2, "Base radial velocity", "m s-1");

		///<summary>Vertically-integrated liquid (kg m-1)</summary>
		public static Parameter VerticallyIntegratedLiquid { get; } =
			new Parameter(ParameterCategory.Radar, 3, "Vertically-integrated liquid", "kg m-1");

		///<summary>Layer-maximum base reflectivity (dB)</summary>
		public static Parameter LayerMaximumBaseReflectivity { get; } =
			new Parameter(ParameterCategory.Radar, 4, "Layer-maximum base reflectivity", "dB");

		///<summary>Precipitation (kg m-2)</summary>
		public static Parameter Precipitation { get; } = new Parameter(ParameterCategory.Radar, 5, "Precipitation", "kg m-2");

		///<summary>Radar spectra (1) (-)</summary>
		public static Parameter RadarSpectra1 { get; } = new Parameter(ParameterCategory.Radar, 6, "Radar spectra (1)", "-");

		///<summary>Radar spectra (2) (-)</summary>
		public static Parameter RadarSpectra2 { get; } = new Parameter(ParameterCategory.Radar, 7, "Radar spectra (2)", "-");

		///<summary>Radar spectra (3) (-)</summary>
		public static Parameter RadarSpectra3 { get; } = new Parameter(ParameterCategory.Radar, 8, "Radar spectra (3)", "-");

		#endregion

		#region Product Discipline 0 - Meteorological products, Parameter Category 16: Forecast Radar Imagery

		///<summary>Equivalent radar reflectivity factor for rain (m m6 m-3)</summary>
		public static Parameter EquivalentRadarReflectivityFactorForRain { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 0, "Equivalent radar reflectivity factor for rain", "m m6 m-3");

		///<summary>Equivalent radar reflectivity factor for snow (m m6 m-3)</summary>
		public static Parameter EquivalentRadarReflectivityFactorForSnow { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 1, "Equivalent radar reflectivity factor for snow", "m m6 m-3");

		///<summary>Equivalent radar reflectivity factor for parameterized convection (m m6 m-3)</summary>
		public static Parameter EquivalentRadarReflectivityFactorForParameterizedConvection { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 2, "Equivalent radar reflectivity factor for parameterized convection", "m m6 m-3");

		///<summary>Echo Top (m)</summary>
		public static Parameter EchoTop { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 3, "Echo Top", "m");

		///<summary>Reflectivity (dB)</summary>
		public static Parameter Reflectivity { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 4, "Reflectivity", "dB");

		///<summary>Composite reflectivity (dB)</summary>
		public static Parameter CompositeReflectivity { get; } = new Parameter(ParameterCategory.ForecastRadarImagery, 5, "Composite reflectivity", "dB");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 18: Nuclear/radiology

		///<summary>Air concentration of Caesium 137 (Bq m-3)</summary>
		public static Parameter AirConcentrationOfCaesium137 { get; } = new Parameter(ParameterCategory.NuclearRadiology, 0,
			"Air concentration of Caesium 137", "Bq m-3");

		///<summary>Air concentration of Iodine 131 (Bq m-3)</summary>
		public static Parameter AirConcentrationOfIodine131 { get; } = new Parameter(ParameterCategory.NuclearRadiology, 1,
			"Air concentration of Iodine 131", "Bq m-3");

		///<summary>Air concentration of radioactive pollutant (Bq m-3)</summary>
		public static Parameter AirConcentrationOfRadioactivePollutant { get; } = new Parameter(ParameterCategory.NuclearRadiology,
			2, "Air concentration of radioactive pollutant", "Bq m-3");

		///<summary>Ground deposition of Caesium 137 (Bq m-2)</summary>
		public static Parameter GroundDepositionOfCaesium137 { get; } = new Parameter(ParameterCategory.NuclearRadiology, 3,
			"Ground deposition of Caesium 137", "Bq m-2");

		///<summary>Ground deposition of Iodine 131 (Bq m-2)</summary>
		public static Parameter GroundDepositionOfIodine131 { get; } = new Parameter(ParameterCategory.NuclearRadiology, 4,
			"Ground deposition of Iodine 131", "Bq m-2");

		///<summary>Ground deposition of radioactive pollutant (Bq m-2)</summary>
		public static Parameter GroundDepositionOfRadioactivePollutant { get; } = new Parameter(ParameterCategory.NuclearRadiology,
			5, "Ground deposition of radioactive pollutant", "Bq m-2");

		///<summary>Time-integrated air concentration of caesium pollutant (Bq s m-3)</summary>
		public static Parameter TimeIntegratedAirConcentrationOfCaesiumPollutant { get; } = new Parameter(
			ParameterCategory.NuclearRadiology, 6, "Time-integrated air concentration of caesium pollutant", "Bq s m-3");

		///<summary>Time-integrated air concentration of iodine pollutant (Bq s m-3)</summary>
		public static Parameter TimeIntegratedAirConcentrationOfIodinePollutant { get; } = new Parameter(
			ParameterCategory.NuclearRadiology, 7, "Time-integrated air concentration of iodine pollutant", "Bq s m-3");

		///<summary>Time-integrated air concentration of radioactive pollutant (Bq s m-3)</summary>
		public static Parameter TimeIntegratedAirConcentrationOfRadioactivePollutant { get; } = new Parameter(
			ParameterCategory.NuclearRadiology, 8, "Time-integrated air concentration of radioactive pollutant", "Bq s m-3");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 19: Physical atmospheric properties

		///<summary>Visibility (m)</summary>
		public static Parameter Visibility { get; } =
			new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 0, "Visibility", "m");

		///<summary>Albedo (%)</summary>
		public static Parameter Albedo { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 1, "Albedo", "%");

		///<summary>Thunderstorm probability (%)</summary>
		public static Parameter ThunderstormProbability { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties,
			2, "Thunderstorm probability", "%");

		///<summary>mixed layer depth (m)</summary>
		public static Parameter MixedLayerDepth { get; } =
			new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 3, "mixed layer depth", "m");

		///<summary>Volcanic ash (Code table (4.206))</summary>
		public static Parameter VolcanicAsh { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 4,
			"Volcanic ash", "Code table (4.206)");

		///<summary>Icing top (m)</summary>
		public static Parameter IcingTop { get; } =
			new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 5, "Icing top", "m");

		///<summary>Icing base (m)</summary>
		public static Parameter IcingBase { get; } =
			new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 6, "Icing base", "m");

		///<summary>Icing (Code table (4.207))</summary>
		public static Parameter Icing { get; } =
			new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 7, "Icing", "Code table (4.207)");

		///<summary>Turbulence top (m)</summary>
		public static Parameter TurbulenceTop { get; } =
			new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 8, "Turbulence top", "m");

		///<summary>Turbulence base (m)</summary>
		public static Parameter TurbulenceBase { get; } =
			new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 9, "Turbulence base", "m");

		///<summary>Turbulence (Code table (4.208))</summary>
		public static Parameter Turbulence { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 10,
			"Turbulence", "Code table (4.208)");

		///<summary>Turbulent kinetic energy (J kg-1)</summary>
		public static Parameter TurbulentKineticEnergy { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties,
			11, "Turbulent kinetic energy", "J kg-1");

		///<summary>Planetary boundary layer regime (Code table (4.209))</summary>
		public static Parameter PlanetaryBoundaryLayerRegime { get; } = new Parameter(
			ParameterCategory.PhysicalAtmosphericProperties, 12, "Planetary boundary layer regime", "Code table (4.209)");

		///<summary>Contrail intensity (Code table (4.210))</summary>
		public static Parameter ContrailIntensity { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 13,
			"Contrail intensity", "Code table (4.210)");

		///<summary>Contrail engine type (Code table (4.211))</summary>
		public static Parameter ContrailEngineType { get; } = new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 14,
			"Contrail engine type", "Code table (4.211)");

		///<summary>Contrail top (m)</summary>
		public static Parameter ContrailTop { get; } =
			new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 15, "Contrail top", "m");

		///<summary>Contrail (base)</summary>
		public static Parameter Contrail { get; } =
			new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 16, "Contrail", "base");

		///<summary>Weather (Code Table 4.225)</summary>
		public static Parameter Weather { get; } =
			new Parameter(ParameterCategory.PhysicalAtmosphericProperties, 25, "Weather", "Code Table 4.225");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 20 Atmospheric Chemical Constituents category

		public static Parameter MassDensity { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 0, "Mass Density", "kg m-3");

		public static Parameter ColumnIntegratedMassDensity { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 1, "Column-Integrated Mass Density", "kg m-2");

		public static Parameter MassMixingRatio { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 2, "Mass Mixing Ratio", "kg kg-1");

		public static Parameter AtmosphereEmissionMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 3, "Atmosphere Emission Mass Flux", "kg m-2s-1");

		public static Parameter AtmosphereNetProductionMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 4, "Atmosphere Net Production Mass Flux", "kg m-2s-1");

		public static Parameter AtmosphereNetProductionAndEmissionMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 5, "Atmosphere Net Production And Emission Mass Flux", "kg m-2s-1");

		public static Parameter SurfaceDryDepositionMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 6, "Surface Dry Deposition Mass Flux", "kg m-2s-1");

		public static Parameter SurfaceWetDepositionMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 7, "Surface Wet Deposition Mass Flux", "kg m-2s-1");

		public static Parameter AtmosphereReEmissionMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 8, "Atmosphere Re-Emission Mass Flux", "kg m-2s-1");

		public static Parameter WetDepositionByLargeScalePrecipitationMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 9, "Wet Deposition by Large-Scale Precipitation Mass Flux", "kg m-2s-1");

		public static Parameter WetDepositionByConvectivePrecipitationMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 10, "Wet Deposition by Convective Precipitation Mass Flux", "kg m-2s-1");

		public static Parameter SedimentationMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 11, "Sedimentation Mass Flux", "kg m-2s-1");

		public static Parameter DryDepositionMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 12, "Dry Deposition Mass Flux", "kg m-2s-1");

		public static Parameter TransferFromHydrophobicToHydrophilic { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 13, "Transfer From Hydrophobic to Hydrophilic", "kg kg-1s-1");

		public static Parameter TransferFromSO2ToSO4 { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 14, "Transfer From SO2 (Sulphur Dioxide) to SO4 (Sulphate)", "kg kg-1s-1");

		public static Parameter DryDepositionVelocity { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 15, "Dry deposition velocity", "m s-1");

		public static Parameter MassMixingRatioWithRespectToDryAir { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 16, "Mass mixing ratio with respect to dry air", "kg kg-1");

		public static Parameter MassMixingRatioWithRespectToWetAir { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 17, "Mass mixing ratio with respect to wet air", "kg kg-1");

		public static Parameter PotentialOfHydrogen { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 18, "Potential of hydrogen (pH)", "pH");

		public static Parameter AmountInAtmosphere { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 50, "Amount in Atmosphere", "mol");

		public static Parameter ConcentrationInAir { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 51, "Concentration In Air", "mol m-3");

		public static Parameter VolumeMixingRatio { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 52, "Volume Mixing Ratio", "mol mol-1");

		public static Parameter ChemicalGrossProductionRateOfConcentration { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 53, "Chemical Gross Production Rate of Concentration", "mol m-3s-1");

		public static Parameter ChemicalGrossDestructionRateOfConcentration { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 54, "Chemical Gross Destruction Rate of Concentration", "mol m-3s-1");

		public static Parameter SurfaceFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 55, "Surface Flux", "mol m-2s-1");

		public static Parameter ChangesOfAmountInAtmosphere { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 56, "Changes Of Amount in Atmosphere", "mol s-1");

		public static Parameter TotalYearlyAverageBurdenOfTheAtmosphere { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 57, "Total Yearly Average Burden of The Atmosphere", "mol");

		public static Parameter TotalYearlyAverageAtmosphericLoss { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 58, "Total Yearly Average Atmospheric Loss", "mol s-1");

		public static Parameter AerosolNumberConcentration { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 59, "Aerosol Number Concentration", "m-3");

		public static Parameter AerosolSpecificNumberConcentration { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 60, "Aerosol Specific Number Concentration", "kg-1");

		public static Parameter MaximumOfMassDensity { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 61, "Maximum of Mass Density", "kg m-3");

		public static Parameter HeightOfMassDensity { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 62, "Height of Mass Density", "m");

		public static Parameter ColumnAveragedMassDensityInLayer { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 63, "Column-Averaged Mass Density in Layer", "kg m-3");

		public static Parameter MoleFractionWithRespectToDryAir { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 64, "Mole fraction with respect to dry air", "mol mol-1");

		public static Parameter MoleFractionWithRespectToWetAir { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 65, "Mole fraction with respect to wet air", "mol mol-1");

		public static Parameter ColumnIntegratedInCloudScavengingRateByPrecipitation { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 66, "Column-integrated in-cloud scavenging rate by precipitation", "kg m-2 s-1");

		public static Parameter ColumnIntegratedBelowCloudScavengingRateByPrecipitation { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 67, "Column-integrated below-cloud scavenging rate by precipitation", "kg m-2 s-1");

		public static Parameter ColumnIntegratedReleaseRateFromEvaporatingPrecipitation { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 68, "Column-integrated release rate from evaporating precipitation", "kg m-2 s-1");

		public static Parameter ColumnIntegratedInCloudScavengingRateByLargeScalePrecipitation { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 69, "Column-integrated in-cloud scavenging rate by large-scale precipitation", "kg m-2 s-1");

		public static Parameter ColumnIntegratedBelowCloudScavengingRateByLargeScalePrecipitation { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 70, "Column-integrated below-cloud scavenging rate by large-scale precipitation", "kg m-2 s-1");

		public static Parameter ColumnIntegratedReleaseRateFromEvaporatingLargeScalePrecipitation { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 71, "Column-integrated release rate from evaporating large-scale precipitation", "kg m-2 s-1");

		public static Parameter ColumnIntegratedInCloudScavengingRateByConvectivePrecipitation { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 72, "Column-integrated in-cloud scavenging rate by convective precipitation", "kg m-2 s-1");

		public static Parameter ColumnIntegratedBelowCloudScavengingRateByConvectivePrecipitation { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 73, "Column-integrated below-cloud scavenging rate by convective precipitation", "kg m-2 s-1");

		public static Parameter ColumnIntegratedReleaseRateFromEvaporatingConvectivePrecipitation { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 74, "Column-integrated release rate from evaporating convective precipitation", "kg m-2 s-1");

		public static Parameter WildfireFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 75, "Wildfire flux", "kg m-2 s-1");

		public static Parameter EmissionRate { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 76, "Emission Rate", "kg kg-1 s-1");

		public static Parameter SurfaceEmissionFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 77, "Surface Emission flux", "kg m-2 s-1");

		public static Parameter ColumnIntegratedEastwardMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 78, "Column integrated eastward mass flux", "kg m-2 s-1");

		public static Parameter ColumnIntegratedNorthwardMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 79, "Column integrated northward mass flux", "kg m-2 s-1");

		public static Parameter ColumnIntegratedDivergenceOfMassFlux { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 80, "Column integrated divergence of mass flux", "kg m-2 s-1");

		public static Parameter ColumnIntegratedNetSource { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 81, "Column integrated net source", "kg m-2 s-1");

		public static Parameter SurfaceAreaDensity { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 100, "Surface Area Density (Aerosol)", "m-1");

		public static Parameter VerticalVisualRange { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 101, "Vertical Visual Range", "m");

		public static Parameter AerosolOpticalThickness { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 102, "Aerosol Optical Thickness", "Numeric");

		public static Parameter SingleScatteringAlbedo { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 103, "Single Scattering Albedo", "Numeric");

		public static Parameter AsymmetryFactor { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 104, "Asymmetry Factor", "Numeric");

		public static Parameter AerosolExtinctionCoefficient { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 105, "Aerosol Extinction Coefficient", "m-1");

		public static Parameter AerosolAbsorptionCoefficient { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 106, "Aerosol Absorption Coefficient", "m-1");

		public static Parameter AerosolLidarBackscatterFromSatellite { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 107, "Aerosol Lidar Backscatter from Satellite", "m-1sr-1");

		public static Parameter AerosolLidarBackscatterFromTheGround { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 108, "Aerosol Lidar Backscatter from the Ground", "m-1sr-1");

		public static Parameter AerosolLidarExtinctionFromSatellite { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 109, "Aerosol Lidar Extinction from Satellite", "m-1");

		public static Parameter AerosolLidarExtinctionFromTheGround { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 110, "Aerosol Lidar Extinction from the Ground", "m-1");

		public static Parameter AngstromExponent { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 111, "Angstrom Exponent", "Numeric");

		public static Parameter ScatteringAerosolOpticalThickness { get; } =
			new Parameter(ParameterCategory.AtmosphericChemicalConstituents, 112, "Scattering Aerosol Optical Thickness", "Numeric");

		#endregion

		#region Product Discipline 0: Meteorological products, Parameter Category 253: ASCII character string

		///<summary>Arbitrary text string CCITTIA5</summary>
		public static Parameter ArbitraryTextStringCcittia5 { get; } =
			new Parameter(ParameterCategory.CcittIa5String, 0, "Arbitrary text string CCITTIA5", "");

		#endregion

		#region Product Discipline 1: Hydrologic products, Parameter Category 0: Hydrology basic products

		///<summary>Flash flood guidance (Encoded as an accumulation over a floating subinterval of time between the reference time and valid time) (kg m-2)</summary>
		public static Parameter FlashFloodGuidance { get; } = new Parameter(ParameterCategory.HydrologyBasicProducts, 0,
			"Flash flood guidance (Encoded as an accumulation over a floating subinterval of time between the reference time and valid time)",
			"kg m-2");

		///<summary>Flash flood runoff (Encoded as an accumulation over a floating subinterval of time) (kg m-2)</summary>
		public static Parameter FlashFloodRunoff { get; } = new Parameter(ParameterCategory.HydrologyBasicProducts, 1,
			"Flash flood runoff (Encoded as an accumulation over a floating subinterval of time)", "kg m-2");

		///<summary>Remotely sensed snow cover (code table 4.215)</summary>
		public static Parameter RemotelySensedSnowCover { get; } = new Parameter(ParameterCategory.HydrologyBasicProducts, 2,
			"Remotely sensed snow cover (code table 4.215)", "");

		///<summary>Elevation of snow covered terrain (code table 4.216)</summary>
		public static Parameter ElevationOfSnowCoveredTerrain { get; } = new Parameter(ParameterCategory.HydrologyBasicProducts, 3,
			"Elevation of snow covered terrain (code table 4.216)", "");

		///<summary>Snow water equivalent percent of normal (%)</summary>
		public static Parameter SnowWaterEquivalentPercentOfNormal { get; } =
			new Parameter(ParameterCategory.HydrologyBasicProducts, 4, "Snow water equivalent percent of normal", "%");

		#endregion

		#region Product Discipline 1: Hydrologic products, Parameter Category 1: Hydrology probabilities

		///<summary>Conditional percent precipitation amount fractile for an overall period (kg m-2(Encoded as an accumulation).)</summary>
		public static Parameter ConditionalPercentPrecipitationAmountFractileForAnOverallPeriod { get; } = new Parameter(
			ParameterCategory.HydrologyProbabilities, 0, "Conditional percent precipitation amount fractile for an overall period",
			"kg m-2(Encoded as an accumulation).");

		///<summary>Percent precipitation in a sub-period of an overall period (Encoded as per cent accumulation over the sub-period) (%)</summary>
		public static Parameter PercentPrecipitationInASubPeriodOfAnOverallPeriod { get; } = new Parameter(
			ParameterCategory.HydrologyProbabilities, 1,
			"Percent precipitation in a sub-period of an overall period (Encoded as per cent accumulation over the sub-period)",
			"%");

		///<summary>Probability of 0.01 inch of precipitation (POP) (%)</summary>
		public static Parameter ProbabilityOf001InchOfPrecipitationPop { get; } =
			new Parameter(ParameterCategory.HydrologyProbabilities, 2, "Probability of 0.01 inch of precipitation (POP)", "%");

		#endregion

		#region Product Discipline 2: Land surface products, Parameter Category 0: Vegetation/Biomass

		///<summary>Land cover (1=land, 2=sea) (Proportion)</summary>
		public static Parameter LandCover { get; } =
			new Parameter(ParameterCategory.VegetationBiomass, 0, "Land cover (1=land, 2=sea)", "Proportion");

		///<summary>Surface roughness (m)</summary>
		public static Parameter SurfaceRoughness { get; } =
			new Parameter(ParameterCategory.VegetationBiomass, 1, "Surface roughness", "m");

		///<summary>Soil temperature</summary>
		public static Parameter SoilTemperature { get; } =
			new Parameter(ParameterCategory.VegetationBiomass, 2, "Soil temperature", "");

		///<summary>Soil moisture content (kg m-2)</summary>
		public static Parameter SoilMoistureContent { get; } =
			new Parameter(ParameterCategory.VegetationBiomass, 3, "Soil moisture content", "kg m-2");

		///<summary>Vegetation (%)</summary>
		public static Parameter Vegetation { get; } = new Parameter(ParameterCategory.VegetationBiomass, 4, "Vegetation", "%");

		///<summary>Water runoff (kg m-2)</summary>
		public static Parameter WaterRunoff { get; } =
			new Parameter(ParameterCategory.VegetationBiomass, 5, "Water runoff", "kg m-2");

		///<summary>Evapotranspiration (kg-2 s-1)</summary>
		public static Parameter Evapotranspiration { get; } =
			new Parameter(ParameterCategory.VegetationBiomass, 6, "Evapotranspiration", "kg-2 s-1");

		///<summary>Model terrain height (m)</summary>
		public static Parameter ModelTerrainHeight { get; } =
			new Parameter(ParameterCategory.VegetationBiomass, 7, "Model terrain height", "m");

		///<summary>Land use (Code table (4.212))</summary>
		public static Parameter LandUse { get; } =
			new Parameter(ParameterCategory.VegetationBiomass, 8, "Land use", "Code table (4.212)");

		#endregion

		#region Product Discipline 2: Land surface products, Parameter Category 3: Soil Products

		///<summary>Soil type (Code table (4.213))</summary>
		public static Parameter SoilType { get; } =
			new Parameter(ParameterCategory.SoilProducts, 0, "Soil type", "Code table (4.213)");

		///<summary>Upper layer soil temperature (K)</summary>
		public static Parameter UpperLayerSoilTemperature { get; } =
			new Parameter(ParameterCategory.SoilProducts, 1, "Upper layer soil temperature", "K");

		///<summary>Upper layer soil moisture (kg m-3)</summary>
		public static Parameter UpperLayerSoilMoisture { get; } =
			new Parameter(ParameterCategory.SoilProducts, 2, "Upper layer soil moisture", "kg m-3");

		///<summary>Lower layer soil moisture (kg m-3)</summary>
		public static Parameter LowerLayerSoilMoisture { get; } =
			new Parameter(ParameterCategory.SoilProducts, 3, "Lower layer soil moisture", "kg m-3");

		///<summary>Bottom layer soil temperature (K)</summary>
		public static Parameter BottomLayerSoilTemperature { get; } =
			new Parameter(ParameterCategory.SoilProducts, 4, "Bottom layer soil temperature", "K");

		#endregion

		#region Product Discipline 2: Land surface products, Parameter Category 4: Fire Weather

		///<summary>Haines Index (Numeric)</summary>
		public static Parameter HainesIndex { get; } = new Parameter(ParameterCategory.FireWeather, 2, "Haines Index", "Numeric");

		#endregion

		#region Product Discipline 3: Space products, Parameter Category 0: Image format products

		///<summary>Scaled radiance (numeric)</summary>
		public static Parameter ScaledRadiance { get; } =
			new Parameter(ParameterCategory.ImageFormatProducts, 0, "Scaled radiance", "numeric");

		///<summary>Scaled albedo (numeric)</summary>
		public static Parameter ScaledAlbedo { get; } =
			new Parameter(ParameterCategory.ImageFormatProducts, 1, "Scaled albedo", "numeric");

		///<summary>Scaled brightness temperature (numeric)</summary>
		public static Parameter ScaledBrightnessTemperature { get; } = new Parameter(ParameterCategory.ImageFormatProducts, 2,
			"Scaled brightness temperature", "numeric");

		///<summary>Scaled precipitable water (numeric)</summary>
		public static Parameter ScaledPrecipitableWater { get; } =
			new Parameter(ParameterCategory.ImageFormatProducts, 3, "Scaled precipitable water", "numeric");

		///<summary>Scaled lifted index (numeric)</summary>
		public static Parameter ScaledLiftedIndex { get; } =
			new Parameter(ParameterCategory.ImageFormatProducts, 4, "Scaled lifted index", "numeric");

		///<summary>Scaled cloud top pressure (numeric)</summary>
		public static Parameter ScaledCloudTopPressure { get; } =
			new Parameter(ParameterCategory.ImageFormatProducts, 5, "Scaled cloud top pressure", "numeric");

		///<summary>Scaled skin temperature (numeric)</summary>
		public static Parameter ScaledSkinTemperature { get; } =
			new Parameter(ParameterCategory.ImageFormatProducts, 6, "Scaled skin temperature", "numeric");

		///<summary>Cloud mask (Code table 4.217)</summary>
		public static Parameter CloudMask { get; } =
			new Parameter(ParameterCategory.ImageFormatProducts, 7, "Cloud mask", "Code table 4.217");

		#endregion

		#region Product Discipline 3: Space products, Parameter Category 1: Quantitative products

		///<summary>Estimated precipitation (kg m-2)</summary>
		public static Parameter EstimatedPrecipitation { get; } =
			new Parameter(ParameterCategory.QuantitativeProducts, 0, "Estimated precipitation", "kg m-2");

		#endregion

		#region Product Discipline 10: Oceanographic products, Parameter Category 0: Waves

		///<summary>Wave spectra (1) (-)</summary>
		public static Parameter WaveSpectra1 { get; } = new Parameter(ParameterCategory.Waves, 0, "Wave spectra (1)", "-");

		///<summary>Wave spectra (2) (-)</summary>
		public static Parameter WaveSpectra2 { get; } = new Parameter(ParameterCategory.Waves, 1, "Wave spectra (2)", "-");

		///<summary>Wave spectra (3) (-)</summary>
		public static Parameter WaveSpectra3 { get; } = new Parameter(ParameterCategory.Waves, 2, "Wave spectra (3)", "-");

		///<summary>Significant height of combined wind waves and swell (m)</summary>
		public static Parameter SignificantHeightOfCombinedWindWavesAndSwell { get; } = new Parameter(ParameterCategory.Waves, 3,
			"Significant height of combined wind waves and swell", "m");

		///<summary>Direction of wind waves (Degree true)</summary>
		public static Parameter DirectionOfWindWaves { get; } =
			new Parameter(ParameterCategory.Waves, 4, "Direction of wind waves", "Degree true");

		///<summary>Significant height of wind waves (m)</summary>
		public static Parameter SignificantHeightOfWindWaves { get; } =
			new Parameter(ParameterCategory.Waves, 5, "Significant height of wind waves", "m");

		///<summary>Mean period of wind waves (s)</summary>
		public static Parameter MeanPeriodOfWindWaves { get; } =
			new Parameter(ParameterCategory.Waves, 6, "Mean period of wind waves", "s");

		///<summary>Direction of swell waves (Degree true)</summary>
		public static Parameter DirectionOfSwellWaves { get; } =
			new Parameter(ParameterCategory.Waves, 7, "Direction of swell waves", "Degree true");

		///<summary>Significant height of swell waves (m)</summary>
		public static Parameter SignificantHeightOfSwellWaves { get; } =
			new Parameter(ParameterCategory.Waves, 8, "Significant height of swell waves", "m");

		///<summary>Mean period of swell waves (s)</summary>
		public static Parameter MeanPeriodOfSwellWaves { get; } =
			new Parameter(ParameterCategory.Waves, 9, "Mean period of swell waves", "s");

		///<summary>Primary wave direction (Degree true)</summary>
		public static Parameter PrimaryWaveDirection { get; } =
			new Parameter(ParameterCategory.Waves, 10, "Primary wave direction", "Degree true");

		///<summary>Primary wave mean period (s)</summary>
		public static Parameter PrimaryWaveMeanPeriod { get; } =
			new Parameter(ParameterCategory.Waves, 11, "Primary wave mean period", "s");

		///<summary>Secondary wave direction (Degree true)</summary>
		public static Parameter SecondaryWaveDirection { get; } =
			new Parameter(ParameterCategory.Waves, 12, "Secondary wave direction", "Degree true");

		///<summary>Secondary wave mean period (s)</summary>
		public static Parameter SecondaryWaveMeanPeriod { get; } =
			new Parameter(ParameterCategory.Waves, 13, "Secondary wave mean period", "s");

		///<summary>Direction of combined wind waves and swell (deg)</summary>
		public static Parameter DirectionOfCombinedWindWavesAndSwell { get; } = new Parameter(ParameterCategory.Waves, 14,
			"Direction of combined wind waves and swell", "Degree true");

		///<summary>Period of combined wind waves and swell (s)</summary>
		public static Parameter PeriodOfCombinedWindWavesAndSwell { get; } = new Parameter(ParameterCategory.Waves, 15,
			"Period of combined wind waves and swell", "s");

		///<summary>Inverse mean wave frequency</summary>
		public static Parameter InverseMeanWaveFrequency { get; } = new Parameter(ParameterCategory.Waves, 25,
			"Inverse mean wave frequency", "s");

        ///<summary>Peak wave period</summary>
        public static Parameter PeakWavePeriod { get; } = new Parameter
			(ParameterCategory.Waves, 34,
			  "Peak wave period", "s");

		#endregion

		#region Product Discipline 10: Oceanographic products, Parameter Category 1: Currents

		///<summary>Current direction (Degree true)</summary>
		public static Parameter CurrentDirection { get; } =
			new Parameter(ParameterCategory.Currents, 0, "Current direction", "Degree true");

		///<summary>Current speed (m s-1)</summary>
		public static Parameter CurrentSpeed { get; } = new Parameter(ParameterCategory.Currents, 1, "Current speed", "m s-1");

		///<summary>u-component of current (m s-1)</summary>
		public static Parameter UComponentOfCurrent { get; } =
			new Parameter(ParameterCategory.Currents, 2, "u-component of current", "m s-1");

		///<summary>v-component of current (m s-1)</summary>
		public static Parameter VComponentOfCurrent { get; } =
			new Parameter(ParameterCategory.Currents, 3, "v-component of current", "m s-1");

		#endregion

		#region Product Discipline 10: Oceanographic products, Parameter Category 2: Ice

		///<summary>Ice cover (Proportion)</summary>
		public static Parameter IceCover { get; } = new Parameter(ParameterCategory.Ice, 0, "Ice cover", "Proportion");

		///<summary>Ice thickness (m)</summary>
		public static Parameter IceThickness { get; } = new Parameter(ParameterCategory.Ice, 1, "Ice thickness", "m");

		///<summary>Direction of ice drift (Degree true)</summary>
		public static Parameter DirectionOfIceDrift { get; } =
			new Parameter(ParameterCategory.Ice, 2, "Direction of ice drift", "Degree true");

		///<summary>Speed of ice drift (m s-1)</summary>
		public static Parameter SpeedOfIceDrift { get; } = new Parameter(ParameterCategory.Ice, 3, "Speed of ice drift", "m s-1");

		///<summary>u-component of ice drift (m s-1)</summary>
		public static Parameter UComponentOfIceDrift { get; } =
			new Parameter(ParameterCategory.Ice, 4, "u-component of ice drift", "m s-1");

		///<summary>v-component of ice drift (m s-1)</summary>
		public static Parameter VComponentOfIceDrift { get; } =
			new Parameter(ParameterCategory.Ice, 5, "v-component of ice drift", "m s-1");

		///<summary>Ice growth rate (m s-1)</summary>
		public static Parameter IceGrowthRate { get; } = new Parameter(ParameterCategory.Ice, 6, "Ice growth rate", "m s-1");

		///<summary>Ice divergence (s-1)</summary>
		public static Parameter IceDivergence { get; } = new Parameter(ParameterCategory.Ice, 7, "Ice divergence", "s-1");

		///<summary>Ice Temperature (K)</summary>
		public static Parameter IceTemperature { get; } = new Parameter(ParameterCategory.Ice, 8, "Ice Temperature", "K");

		#endregion

		#region Product Discipline 10: Oceanographic products, Parameter Category 3: Surface Properties

		///<summary>Water temperature (K)</summary>
		public static Parameter WaterTemperature { get; } =
			new Parameter(ParameterCategory.SurfaceProperties, 0, "Water temperature", "K");

		///<summary>Deviation of sea level from mean (m)</summary>
		public static Parameter DeviationOfSeaLevelFromMean { get; } =
			new Parameter(ParameterCategory.SurfaceProperties, 1, "Deviation of sea level from mean", "m");

		#endregion

		#region Product Discipline 10: Oceanographic products, Parameter Category 4: Sub-surface Properties

		///<summary>Main thermocline depth (m)</summary>
		public static Parameter MainThermoclineDepth { get; } =
			new Parameter(ParameterCategory.SubSurfaceProperties, 0, "Main thermocline depth", "m");

		///<summary>Main thermocline anomaly (m)</summary>
		public static Parameter MainThermoclineAnomaly { get; } =
			new Parameter(ParameterCategory.SubSurfaceProperties, 1, "Main thermocline anomaly", "m");

		///<summary>Transient thermocline depth (m)</summary>
		public static Parameter TransientThermoclineDepth { get; } =
			new Parameter(ParameterCategory.SubSurfaceProperties, 2, "Transient thermocline depth", "m");

		///<summary>Salinity (kg kg-1)</summary>
		public static Parameter Salinity { get; } =
			new Parameter(ParameterCategory.SubSurfaceProperties, 3, "Salinity", "kg kg-1");

		#endregion

		private static List<Parameter> GetListOfParameterProperties(
#if NET5_0_OR_GREATER
        [System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembers(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicProperties)]
#endif
			Type parentClassType)
		{
			PropertyInfo[] propertyInfos = parentClassType.GetProperties()
				.Where(pi => pi.PropertyType == typeof(Parameter))
				.ToArray();
			var parameters = new List<Parameter>(propertyInfos.Length);
			foreach (PropertyInfo propertyInfo in propertyInfos)
			{
				parameters.Add((Parameter)propertyInfo.GetValue(null));
			}

			return parameters;
		}

		private static IReadOnlyDictionary<ParameterCategory, IReadOnlyCollection<Parameter>>
			BuildParameterDictionary(IList<Parameter> parameters)
		{
			return parameters.GroupBy(c => c.Category)
				.ToDictionary(
					g => g.Key,
					g => (IReadOnlyCollection<Parameter>)g.ToImmutableList());
		}

		public static IReadOnlyDictionary<ParameterCategory, IReadOnlyCollection<Parameter>> ParametersByCategory
		{
			get
			{
				if (ParametersByCategoryCache == null)
				{
					List<Parameter> parameters = GetListOfParameterProperties(typeof(Parameter));
					ParametersByCategoryCache = BuildParameterDictionary(parameters);
				}

				return ParametersByCategoryCache;
			}
		}

		private static IReadOnlyDictionary<ParameterCategory, IReadOnlyCollection<Parameter>> ParametersByCategoryCache = null;

		public static IReadOnlyDictionary<ParameterCategory, IReadOnlyCollection<Parameter>>
			ParametersByCategoryWithLocalTables(int centerCode)
		{
			if (centerCode < 0 || centerCode > 254) return ParametersByCategory;

			if (ParametersByCategoryWithLocalTablesCache == null || centerCode != previousCenterCodeCache)
			{
				List<Parameter> parameters = GetListOfParameterProperties(typeof(Parameter));
				if (centerCode == Center.UsNcep.Id)
				{
					parameters.AddRange(GetListOfParameterProperties(typeof(LocalTables.US_NOAA_NCEP_Parameter)));
				}
				else if (centerCode == Center.Offenbach.Id)
				{
					parameters.AddRange(GetListOfParameterProperties(typeof(LocalTables.DE_DWD_Parameter)));
				}

				ParametersByCategoryWithLocalTablesCache = BuildParameterDictionary(parameters);
				previousCenterCodeCache = centerCode;
			}

			return ParametersByCategoryWithLocalTablesCache;
		}

		private static IReadOnlyDictionary<ParameterCategory, IReadOnlyCollection<Parameter>> ParametersByCategoryWithLocalTablesCache = null;
		private static int previousCenterCodeCache = -1;
	}
}
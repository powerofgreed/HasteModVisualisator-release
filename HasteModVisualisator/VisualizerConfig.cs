// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (C) 2025 PoWeRofGreeD
//
// This file is part of the HasteModVisualisator plugin.
//
// HasteModVisualisator is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// HasteModVisualisator is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
using BepInEx.Configuration;
using System;
using System.Linq;

public static class VisualizerConfig
{
    // Main visualizer settings
    public static ConfigEntry<bool> EnableVisualizer;
    public static ConfigEntry<float> Intensity;
    public static ConfigEntry<int> QualityLevel;

    // Beat detection
    public static ConfigEntry<float> BeatSensitivity;
    public static ConfigEntry<float> BeatThreshold;

    // Color settings
    public static ConfigEntry<float> ColorIntensity;
    public static ConfigEntry<float> ColorSaturation;
    public static ConfigEntry<float> BeatResponse;

    // Light settings
    public static ConfigEntry<bool> AffectLighting;
    public static ConfigEntry<float> LightIntensityMultiplier;
    public static ConfigEntry<float> LightColorMultiplier;
    public static ConfigEntry<float> LightColorLerpSpeed;
    public static ConfigEntry<bool> AffectAmbient;
    public static ConfigEntry<float> AmbientIntensityMultiplier;
    public static ConfigEntry<float> AmbientColorMultiplier;
    public static ConfigEntry<float> AmbientColorLerpSpeed;
    public static ConfigEntry<string> SunAnglePreset;
    public static ConfigEntry<float> SunAngleLerpSpeedMultiplier;

    // Cloud settings
    public static ConfigEntry<bool> AffectClouds;
    public static ConfigEntry<float> JumpScaleMultiplier;
    public static ConfigEntry<float> CloudColorIntensity;
    public static ConfigEntry<bool> CrazyCloudColor;
    public static ConfigEntry<float> CrazyCloudColorIntensity;
    public static ConfigEntry<float> CloudColorLerpSpeed;
    public static ConfigEntry<float> CrazyCloudColorLerpSpeed;
    public static ConfigEntry<float> SkyVolumeStrength;
    public static ConfigEntry<float> CloudWindBeatScale;
    public static ConfigEntry<float> VolumeStrengthMinMultiplier;

    // Horizon settings
    public static ConfigEntry<bool> AffectHorizon;
    public static ConfigEntry<float> HorizonColorIntensity;
    public static ConfigEntry<float> HorizonColorDensity;
    public static ConfigEntry<float> HorizonColorLerpSpeed;
    public static ConfigEntry<float> HorizonRemapX;
    public static ConfigEntry<float> HorizonRemapY;
    public static ConfigEntry<float> HorizonRemapZ;
    public static ConfigEntry<float> HorizonRemapW;

    // Effects settings
    public static ConfigEntry<bool> AffectStars;
    public static ConfigEntry<bool> EnableScreenEffects;
    public static ConfigEntry<float> BlurIntensity;

    // Advanced settings
    public static ConfigEntry<bool> ShowDebug;
    public static ConfigEntry<bool> ShowCSVDebug;
    public static ConfigEntry<int> HistoryDuration;
    public static ConfigEntry<int> GaussianKernelSize;
    public static ConfigEntry<float> GaussianKernelIntensity;

    // Per-band CSV configs
    public static ConfigEntry<string> Band_MinThresholds;
    public static ConfigEntry<string> Band_DecayRates;
    public static ConfigEntry<string> Band_Sensitivities;
    public static ConfigEntry<string> Band_ThresholdMultipliers;
    public static ConfigEntry<string> Band_Cooldowns;
    public static ConfigEntry<string> Band_MinExceed;
    public static ConfigEntry<string> Band_BeatDecays;

    public static void Init(ConfigFile config)
    {
        if (config == null) return;

        // Visualizer Group (Top of the list)
        EnableVisualizer = config.Bind("------Visualizer------", "Enabled", true,
            new ConfigDescription("Enable audio-reactive skybox effects", null,
            new ConfigurationManagerAttributes { Order = 300 }));

        Intensity = config.Bind("------Visualizer------", "Intensity", 1f,
            new ConfigDescription("Effect intensity",
                new AcceptableValueRange<float>(0.01f, 3f),
            new ConfigurationManagerAttributes { Order = 299 }));

        QualityLevel = config.Bind("------Visualizer------", "Quality", 3,
            new ConfigDescription("Processing quality (1=Low, 2=Med, 3=High)",
                new AcceptableValueRange<int>(1, 3),
            new ConfigurationManagerAttributes { Order = 298 }));

        // Beat Detection Group
        BeatSensitivity = config.Bind("------Beat Detection------", "Sensitivity !!KEEP CLOSE TO 1.0!!", 1f,
            new ConfigDescription("Beat detection sensitivity",
                new AcceptableValueRange<float>(0.1f, 1.5f),
            new ConfigurationManagerAttributes { Order = 290 }));

        BeatThreshold = config.Bind("------Beat Detection------", "Threshold !!KEEP CLOSE TO 1.0!!", 1f,
            new ConfigDescription("Minimum beat threshold",
                new AcceptableValueRange<float>(0.01f, 5f),
            new ConfigurationManagerAttributes { Order = 289 }));

        // Color Group
        ColorIntensity = config.Bind("------Color------", "Intensity", 1.5f,
            new ConfigDescription("Overall color modulation intensity",
                new AcceptableValueRange<float>(-1f, 5f),
            new ConfigurationManagerAttributes { Order = 280 }));

        ColorSaturation = config.Bind("------Color------", "Saturation", 1f,
            new ConfigDescription("Color saturation boost",
                new AcceptableValueRange<float>(0.01f, 5f),
            new ConfigurationManagerAttributes { Order = 279 }));

        BeatResponse = config.Bind("------Color------", "Beat Response", 1f,
            new ConfigDescription("Beat pulse intensity multiplier",
                new AcceptableValueRange<float>(0.01f, 5f),
            new ConfigurationManagerAttributes { Order = 278 }));

        // Light Group
        AffectLighting = config.Bind("------Light------", "Enable Lighting Effects", true,
            new ConfigDescription("Enable light intensity and color effects", null,
            new ConfigurationManagerAttributes { Order = 270 }));

        LightIntensityMultiplier = config.Bind("------Light------", "Intensity Multiplier", 1f,
            new ConfigDescription("Light intensity modulation",
                new AcceptableValueRange<float>(0.01f, 5f),
            new ConfigurationManagerAttributes { Order = 269 }));

        LightColorMultiplier = config.Bind("------Light------", "Color Multiplier", 1f,
            new ConfigDescription("Light color modulation",
                new AcceptableValueRange<float>(0.01f, 5f),
            new ConfigurationManagerAttributes { Order = 268 }));

        LightColorLerpSpeed = config.Bind("------Light------", "Color Lerp Speed", 1f,
            new ConfigDescription("How fast light color morphs",
                new AcceptableValueRange<float>(0.01f, 10f),
            new ConfigurationManagerAttributes { Order = 267 }));

        AffectAmbient = config.Bind("------Light------", "Enable Ambient Effects", true,
            new ConfigDescription("Enable ambient light color and intensity effects", null,
            new ConfigurationManagerAttributes { Order = 266 }));

        AmbientIntensityMultiplier = config.Bind("------Light------", "Ambient Intensity", 1f,
            new ConfigDescription("Ambient light intensity modulation",
                new AcceptableValueRange<float>(0.01f, 3f),
            new ConfigurationManagerAttributes { Order = 265 }));

        AmbientColorMultiplier = config.Bind("------Light------", "Ambient Color", 1f,
            new ConfigDescription("Ambient light color modulation",
                new AcceptableValueRange<float>(0.01f, 3f),
            new ConfigurationManagerAttributes { Order = 264 }));

        AmbientColorLerpSpeed = config.Bind("------Light------", "Ambient Lerp Speed", 1f,
            new ConfigDescription("How fast ambient color morphs",
                new AcceptableValueRange<float>(0.01f, 10f),
            new ConfigurationManagerAttributes { Order = 263 }));

        SunAnglePreset = config.Bind("------Light------", "Sun Angle Preset", "Disable",
            new ConfigDescription("Sun movement preset: Disable, TrackLength, TotalEnergy",
                new AcceptableValueList<string>("Disable", "TrackLength", "TotalEnergy"),
            new ConfigurationManagerAttributes { Order = 262 }));

        SunAngleLerpSpeedMultiplier = config.Bind("------Light------", "Sun Angle Speed", 1f,
            new ConfigDescription("Speed of sun angle transition (lower = slower)",
                new AcceptableValueRange<float>(0.01f, 5f),
            new ConfigurationManagerAttributes { Order = 261 }));

        // Cloud Group
        AffectClouds = config.Bind("------Clouds------", "Enable Cloud Effects", true,
            new ConfigDescription("Enable cloud pulsing effect", null,
            new ConfigurationManagerAttributes { Order = 250 }));

        CloudColorIntensity = config.Bind("------Clouds------", "Color Intensity", 1f,
            new ConfigDescription("Cloud color shift intensity",
                new AcceptableValueRange<float>(0.01f, 10f),
            new ConfigurationManagerAttributes { Order = 249 }));

        CloudColorLerpSpeed = config.Bind("------Clouds------", "Color Lerp Speed", 1f,
            new ConfigDescription("How fast cloud color morphs",
                new AcceptableValueRange<float>(0.01f, 10f),
            new ConfigurationManagerAttributes { Order = 248 }));

        CrazyCloudColor = config.Bind("------Clouds------", "Enable Crazy Color", false,
            new ConfigDescription("Enable very toxic skybox cloud coloring effects", null,
            new ConfigurationManagerAttributes { Order = 247 }));

        CrazyCloudColorIntensity = config.Bind("------Clouds------", "Crazy Color Intensity", 1f,
            new ConfigDescription("CrazyCloud color shift intensity",
                new AcceptableValueRange<float>(0.01f, 10f),
            new ConfigurationManagerAttributes { Order = 246 }));


        CrazyCloudColorLerpSpeed = config.Bind("------Clouds------", "Crazy Color Lerp Speed", 1f,
            new ConfigDescription("How fast crazy cloud color morphs",
                new AcceptableValueRange<float>(0.01f, 10f),
            new ConfigurationManagerAttributes { Order = 245 }));

        SkyVolumeStrength = config.Bind("------Clouds------", "Volume Strength", 1f,
            new ConfigDescription("Amount to jump cloud remap values on strong beats",
                new AcceptableValueRange<float>(0f, 5f),
            new ConfigurationManagerAttributes { Order = 244 }));

        JumpScaleMultiplier = config.Bind("------Clouds------", "Jump Scale", 1f,
            new ConfigDescription("Jump scale modulation intensity, 0=off",
                new AcceptableValueRange<float>(0.00f, 10f),
            new ConfigurationManagerAttributes { Order = 243 }));

        //VolumeStrengthMinMultiplier = config.Bind("------Clouds------", "Volume Min Multiplier", 0.8f,
        //    new ConfigDescription("Minimum volume strength multiplier",
        //        new AcceptableValueRange<float>(0.1f, 1.0f),
        //    new ConfigurationManagerAttributes { Order = 242 }));

        CloudWindBeatScale = config.Bind("------Clouds------", "Wind Beat Scale", 1f,
            new ConfigDescription("Scale factor for wind speed modulation on beats, 0=off",
                new AcceptableValueRange<float>(0f, 6f),
            new ConfigurationManagerAttributes { Order = 241 }));

        // Horizon Group
        AffectHorizon = config.Bind("------Horizon------", "Enable Horizon Effects", false,
            new ConfigDescription("Enable horizon color and position effects", null,
            new ConfigurationManagerAttributes { Order = 230 }));

        HorizonColorIntensity = config.Bind("------Horizon------", "Color Intensity", 1f,
            new ConfigDescription("Horizon color shift intensity",
                new AcceptableValueRange<float>(0.01f, 5f),
            new ConfigurationManagerAttributes { Order = 229 }));

        HorizonColorDensity = config.Bind("------Horizon------", "Color Density", 1f,
            new ConfigDescription("Horizon color shift density",
                new AcceptableValueRange<float>(0.01f, 5f),
            new ConfigurationManagerAttributes { Order = 228 }));

        HorizonColorLerpSpeed = config.Bind("------Horizon------", "Color Lerp Speed", 1f,
            new ConfigDescription("Horizon color shift lerp speed",
                new AcceptableValueRange<float>(0.01f, 5f),
            new ConfigurationManagerAttributes { Order = 227 }));

        HorizonRemapX = config.Bind("------Horizon------", "Remap X", 0f,
            new ConfigDescription("Horizon remap X value",
                new AcceptableValueRange<float>(-4.0f, 4.0f),
            new ConfigurationManagerAttributes { Order = 226 }));

        HorizonRemapY = config.Bind("------Horizon------", "Remap Y", 0f,
            new ConfigDescription("Horizon remap Y value",
                new AcceptableValueRange<float>(-4.0f, 4.0f),
            new ConfigurationManagerAttributes { Order = 225 }));

        HorizonRemapZ = config.Bind("------Horizon------", "Remap Z", 0f,
            new ConfigDescription("Horizon remap Z value",
                new AcceptableValueRange<float>(-4.0f, 4.0f),
            new ConfigurationManagerAttributes { Order = 224 }));

        HorizonRemapW = config.Bind("------Horizon------", "Remap W", 0f,
            new ConfigDescription("Horizon remap W value",
                new AcceptableValueRange<float>(-4.0f, 4.0f),
            new ConfigurationManagerAttributes { Order = 223 }));

        // Effects Group
        AffectStars = config.Bind("------Effects------", "Affect Stars", false,
            new ConfigDescription("Enable star brightness effect", null,
            new ConfigurationManagerAttributes { Order = 220 }));

        //EnableScreenEffects = config.Bind("------Effects------", "Screen Effects", true,
        //    new ConfigDescription("Enable additional screen effects", null,
        //    new ConfigurationManagerAttributes { Order = 219 }));

        //BlurIntensity = config.Bind("------Effects------", "Blur Intensity", 1f,
        //    new ConfigDescription("Intensity of the blur effect",
        //        new AcceptableValueRange<float>(0.1f, 5f),
        //    new ConfigurationManagerAttributes { Order = 218 }));

        // Advanced Group (Bottom of the list, marked as advanced)
        ShowDebug = config.Bind("Advanced", "Show Debug", false,
            new ConfigDescription("Show visualizer debug information", null,
            new ConfigurationManagerAttributes { Order = 10, IsAdvanced = true }));

        ShowCSVDebug = config.Bind("Advanced", "Show CSV Debug", false,
            new ConfigDescription("Show/hide CSV values", null,
            new ConfigurationManagerAttributes { Order = 9, IsAdvanced = true }));

        HistoryDuration = config.Bind("Advanced", "History Duration", 8,
            new ConfigDescription("Energy history duration in quarters of a second. 4 = 1 second",
                new AcceptableValueRange<int>(4, 12),
            new ConfigurationManagerAttributes { Order = 8, IsAdvanced = true }));

        GaussianKernelSize = config.Bind("Advanced", "Gaussian Kernel Size", 5,
            new ConfigDescription("Size of the Gaussian kernel for smoothing",
                new AcceptableValueList<int>(3, 5, 7, 9, 11),
            new ConfigurationManagerAttributes { Order = 7, IsAdvanced = true }));

        GaussianKernelIntensity = config.Bind("Advanced", "Gaussian Kernel Intensity", 1.5f,
            new ConfigDescription("Intensity of the Gaussian kernel",
                new AcceptableValueRange<float>(0.1f, 5.0f),
            new ConfigurationManagerAttributes { Order = 6, IsAdvanced = true }));

        // Per-band CSV configs (Advanced)
        Band_MinThresholds = config.Bind("Advanced", "Min Thresholds",
            "0.16, 0.13, 0.12, 0.11, 0.10, 0.09, 0.07, 0.06, 0.055",
            new ConfigDescription("Comma-separated minThreshold per band (9 values)", null,
            new ConfigurationManagerAttributes { Order = 5, IsAdvanced = true }));

        Band_DecayRates = config.Bind("Advanced", "Decay Rates",
            "0.96, 0.96, 0.96, 1.19, 1.25, 1.37, 0.91, 0.84, 0.81",
            new ConfigDescription("Comma-separated decayRate per band (9 values)", null,
            new ConfigurationManagerAttributes { Order = 4, IsAdvanced = true }));

        Band_Sensitivities = config.Bind("Advanced", "Sensitivities",
            "1.55, 1.42, 1.31, 1.1, 1.08, 1.04, 1, 1.11, 1.22",
            new ConfigDescription("Comma-separated sensitivity per band (9 values)", null,
            new ConfigurationManagerAttributes { Order = 3, IsAdvanced = true }));

        Band_ThresholdMultipliers = config.Bind("Advanced", "Threshold Multipliers",
            "0.99, 0.98, 0.97, 1.35, 1.3, 1.26, 1.15, 0.97, 0.96",
            new ConfigDescription("Comma-separated beatThresholdMultiplier per band (9 values)", null,
            new ConfigurationManagerAttributes { Order = 2, IsAdvanced = true }));

        Band_Cooldowns = config.Bind("Advanced", "Cooldowns",
            "0.20, 0.18, 0.16, 0.16, 0.16, 0.16, 0.15, 0.15, 0.15",
            new ConfigDescription("Comma-separated beatCooldownTime per band (9 values)", null,
            new ConfigurationManagerAttributes { Order = 1, IsAdvanced = true }));

        Band_MinExceed = config.Bind("Advanced", "Min Exceed",
            "0.11, 0.09, 0.08, 0.075, 0.07, 0.06, 0.05, 0.04, 0.03",
            new ConfigDescription("Comma-separated MinExceed (energy delta) per band (9 values)", null,
            new ConfigurationManagerAttributes { Order = 0, IsAdvanced = true }));

        Band_BeatDecays = config.Bind("Advanced", "Beat Decays",
            "0.98, 0.97, 0.96, 0.86, 0.87, 0.88, 0.89, 0.90, 0.91",
            new ConfigDescription("Comma-separated beatDecay per band (9 values)", null,
            new ConfigurationManagerAttributes { Order = -1, IsAdvanced = true }));
    }

    // Helper to parse comma-separated floats with fallback length.
    public static float[] ParseCsvFloats(string csv, int expected, float[] fallback)
    {
        if (string.IsNullOrWhiteSpace(csv))
        {
            float[] f = new float[expected];
            for (int i = 0; i < expected; i++) f[i] = fallback[i];
            return f;
        }

        try
        {
            var parts = csv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(p => p.Trim())
                           .ToArray();

            var result = new float[expected];
            for (int i = 0; i < expected; i++)
            {
                if (i < parts.Length)
                {
                    if (float.TryParse(parts[i], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float v))
                        result[i] = v;
                    else
                        result[i] = fallback[i];
                }
                else
                {
                    result[i] = fallback[i];
                }
            }
            return result;
        }
        catch
        {
            float[] f = new float[expected];
            for (int i = 0; i < expected; i++) f[i] = fallback[i];
            return f;
        }
    }
}

internal sealed class ConfigurationManagerAttributes
{
    /// <summary>
    /// Should the setting be shown as a percentage (only use with value range settings).
    /// </summary>
    public bool? ShowRangeAsPercent;

    /// <summary>
    /// Custom setting editor (OnGUI code that replaces the default editor provided by ConfigurationManager).
    /// See below for a deeper explanation. Using a custom drawer will cause many of the other fields to do nothing.
    /// </summary>
    public System.Action<BepInEx.Configuration.ConfigEntryBase> CustomDrawer;

    /// <summary>
    /// Custom setting editor that allows polling keyboard input with the Input (or UnityInput) class.
    /// Use either CustomDrawer or CustomHotkeyDrawer, using both at the same time leads to undefined behaviour.
    /// </summary>
    public CustomHotkeyDrawerFunc CustomHotkeyDrawer;

    /// <summary>
    /// Custom setting draw action that allows polling keyboard input with the Input class.
    /// Note: Make sure to focus on your UI control when you are accepting input so user doesn't type in the search box or in another setting (best to do this on every frame).
    /// If you don't draw any selectable UI controls You can use `GUIUtility.keyboardControl = -1;` on every frame to make sure that nothing is selected.
    /// </summary>
    /// <example>
    /// CustomHotkeyDrawer = (ConfigEntryBase setting, ref bool isEditing) =>
    /// {
    ///     if (isEditing)
    ///     {
    ///         // Make sure nothing else is selected since we aren't focusing on a text box with GUI.FocusControl.
    ///         GUIUtility.keyboardControl = -1;
    ///                     
    ///         // Use Input.GetKeyDown and others here, remember to set isEditing to false after you're done!
    ///         // It's best to check Input.anyKeyDown and set isEditing to false immediately if it's true,
    ///         // so that the input doesn't have a chance to propagate to the game itself.
    /// 
    ///         if (GUILayout.Button("Stop"))
    ///             isEditing = false;
    ///     }
    ///     else
    ///     {
    ///         if (GUILayout.Button("Start"))
    ///             isEditing = true;
    ///     }
    /// 
    ///     // This will only be true when isEditing is true and you hold any key
    ///     GUILayout.Label("Any key pressed: " + Input.anyKey);
    /// }
    /// </example>
    /// <param name="setting">
    /// Setting currently being set (if available).
    /// </param>
    /// <param name="isCurrentlyAcceptingInput">
    /// Set this ref parameter to true when you want the current setting drawer to receive Input events.
    /// The value will persist after being set, use it to see if the current instance is being edited.
    /// Remember to set it to false after you are done!
    /// </param>
    public delegate void CustomHotkeyDrawerFunc(BepInEx.Configuration.ConfigEntryBase setting, ref bool isCurrentlyAcceptingInput);

    /// <summary>
    /// Show this setting in the settings screen at all? If false, don't show.
    /// </summary>
    public bool? Browsable;

    /// <summary>
    /// Category the setting is under. Null to be directly under the plugin.
    /// </summary>
    public string Category;

    /// <summary>
    /// If set, a "Default" button will be shown next to the setting to allow resetting to default.
    /// </summary>
    public object DefaultValue;

    /// <summary>
    /// Force the "Reset" button to not be displayed, even if a valid DefaultValue is available. 
    /// </summary>
    public bool? HideDefaultButton;

    /// <summary>
    /// Force the setting name to not be displayed. Should only be used with a <see cref="CustomDrawer"/> to get more space.
    /// Can be used together with <see cref="HideDefaultButton"/> to gain even more space.
    /// </summary>
    public bool? HideSettingName;

    /// <summary>
    /// Optional description shown when hovering over the setting.
    /// Not recommended, provide the description when creating the setting instead.
    /// </summary>
    public string Description;

    /// <summary>
    /// Name of the setting.
    /// </summary>
    public string DispName;

    /// <summary>
    /// Order of the setting on the settings list relative to other settings in a category.
    /// 0 by default, higher number is higher on the list.
    /// </summary>
    public int? Order;

    /// <summary>
    /// Only show the value, don't allow editing it.
    /// </summary>
    public bool? ReadOnly;

    /// <summary>
    /// If true, don't show the setting by default. User has to turn on showing advanced settings or search for it.
    /// </summary>
    public bool? IsAdvanced;

    /// <summary>
    /// Custom converter from setting type to string for the built-in editor textboxes.
    /// </summary>
    public System.Func<object, string> ObjToStr;

    /// <summary>
    /// Custom converter from string to setting type for the built-in editor textboxes.
    /// </summary>
    public System.Func<string, object> StrToObj;
}
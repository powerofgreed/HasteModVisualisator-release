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
using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[BepInPlugin("com.PoG.SkyboxVisualizer", "Skybox Visualizer", "0.0.1")]
public class SkyboxVisualizerPlugin : BaseUnityPlugin
{
    void Awake()
    {
        VisualizerConfig.Init(Config);

        GameObject safetyObj = new GameObject("SceneSafetySystem");
        safetyObj.AddComponent<SceneSafetySystem>();
        DontDestroyOnLoad(safetyObj);

        new Harmony("com.pog.skybox.visualizer").PatchAll();

        Logger.LogInfo("Skybox Visualizer initialized!");
        var _ = PostProcessManager.instance;
    }
}
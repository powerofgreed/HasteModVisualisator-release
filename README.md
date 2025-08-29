### 🎵HasteModVisualisator🎵

https://github.com/user-attachments/assets/daef6df7-71da-4a42-8596-ece591f989bc






## ✨ Features

- 🎵 **Beat‑synchronized visuals** — reacts to bass, mids, and highs independently.
- ☁ **Dynamic clouds** — color shifts, morphing, and motion tied to music energy.
- 💡 **Lighting effects** — sun, ambient light, and starfield respond to track intensity.
- 🌅 **Horizon modulation** — smooth color and position changes on musical peaks.
- ⚙ **Highly configurable** — tweak every parameter via ConfigurationManager.
- 🛠 **Optimized for performance** — easy to port to another Unity games.

## 📦 Requirements

- **[BepInEx 5.x](https://github.com/BepInEx/BepInEx/releases)** (plugin loader)
- **[ConfigurationManager](https://github.com/BepInEx/BepInEx.ConfigurationManager)** — *practically mandatory* for adjusting settings in‑game.
- **[HasteModPlaylist](https://github.com/powerofgreed/HasteModPlaylist-release)** — *highly recommended* for playing custom music that drives the visualizer.

## Installation
1. **Install BepInEx** into your *Haste* game folder if you haven’t already.
Download [BepInEx (x64)](https://github.com/BepInEx/BepInEx/releases)  **BepInEx_win_x64_5.4.23.3.zip**

2. To make Haste hook from BepInEx need to open *\Haste\BepInEx\core* folder and  **delete each file** which starts with **MONO***

3. After first game launch, open *\Haste\BepInEx\config\BepInEx.cfg* and change **HideManagerGameObject = false** to **HideManagerGameObject = true**

4. Download  [**HasteModVisualisator**](https://github.com/powerofgreed/HasteModVisualisator-release/releases/) and extract in game directory.

  **--(Optional) [BepInEx.ConfigurationManager](https://github.com/BepInEx/BepInEx.ConfigurationManager)** - an additional plugin for much easier plugins configuration
  **--(Optional) [HasteModPlaylist](https://github.com/powerofgreed/HasteModPlaylist-release)** - play game and listen you favorite music!

## ⚙ Configuration

All settings are available via **ConfigurationManager**:
- ☁️CRAZY CLOUDS😵 and 🌅HORIZON🌄 effect are disable by default. **TRY IT!**
- 🌞Sun movement is disabled by default.
- Enable/disable individual effects (clouds, lighting, horizon, stars).
- Adjust intensity, color response, smoothing, and beat sensitivity.
- Advanced per‑band controls for fine‑tuning frequency response.

Settings are saved to:
BepInEx/config/HasteModVisualisator.cfg

---

## 📸 Screenshots / Demo

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/3cc0bd3d-62ec-4030-a188-217b7b3e2356" />


---

## 📝 License

This project is licensed under the **LGPL‑3.0‑or‑later** License — see the [LICENSE](LICENSE) file for details.  
© 2025 PoWeRofGreeD

---

## 🙌 Credits

- **PoWeRofGreeD** — development & design
- **BepInEx Team** — plugin framework
- **HarmonyX** — runtime patching
- **HasteModPlaylist** — custom music support
- **ConfigurationManager** — in‑game config UI

---

## 📬 Feedback & Issues

Found a bug or have a feature request?  
Open an [issue](https://github.com/powerofgreed/HasteModVisualisator-release/issues) or start a discussion in the repo.

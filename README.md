# Ghost Statue Mod for Stardew Valley

A SMAPI mod that adds a statue to your farm which generates a ghost every 10 minutes.

## Features

- Spawns ghosts periodically (every 10 minutes)
- Ghosts spawn near the statue location
- Resets spawn timer daily
- Fully configurable spawn intervals

## Installation

1. Install SMAPI (https://smapi.io/)
2. Build this mod or download the compiled DLL
3. Place the mod folder in your `Stardew Valley/Mods` directory
4. Run Stardew Valley

## Requirements

- Stardew Valley 1.5.6+
- SMAPI 3.18.0+

## Configuration

Edit the `config.json` file to customize:
- Ghost spawn interval (in milliseconds)
- Statue location
- Spawn offset distance

## Development

This mod is built in C# using SMAPI. To compile:

```
dotnet build
```

## License

MIT License - Feel free to modify and distribute as needed.

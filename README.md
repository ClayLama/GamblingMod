# GamblingMod
## a Slay the Spire 2 mod

@'
# GamblingMod

A Slay the Spire 2 card mod about gambling and odds. Built on ModSmith.

## Requirements
- Slay the Spire 2 (Steam). We used the public-beta branch.
- ModSmith installed in `Slay the Spire 2\mods\ModSmith`
  (https://github.com/cpimhoff/Sts2-ModSmith/releases/latest)
- .NET SDK (the ModSmith guide says 9; 10 also worked for us)
- MegaDot 4.5.1 (https://megadot.megacrit.com/) or Godot 4.5.1 .NET
- VS Code with the C# extension

## Setup
1. Clone this repo.
2. Open GamblingMod.csproj and change the MegaDot path (search for "megadot")
   to where MegaDot is on YOUR PC. Do not commit that change.
3. Run `dotnet publish` in this folder. It copies the mod into the game's mods folder.
4. Start the game, enable ModSmith and GamblingMod, and play modded.

## Adding a card
1. Copy an existing card in src/ and rename the file and the class.
2. Add its text in GamblingMod/localization/eng/cards.json.
3. Register it in src/StarterContent/StarterContent.cs (one line).
4. Run `dotnet publish`, restart the game, and test.

## Rules
- One card per file, so merges stay clean.
- Never commit game files, decompiled game code, or the original art.
- Use a branch per card and open a pull request.

## Known issues
- The starter content was written for an older game version. GoldPaint and MadeOfGold are disabled.
- Turn off Steam Cloud while testing modded saves, or saves may be deleted on sync.
'@ | Set-Content README.md -Encoding ascii

Built with [ModSmith](https://github.com/cpimhoff/Sts2-ModSmith).

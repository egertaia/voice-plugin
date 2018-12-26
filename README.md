# voice-plugin
[![License](https://img.shields.io/github/license/egertaia/voice-plugin.svg)](LICENSE)
[![Build Status](https://img.shields.io/appveyor/ci/egertaia/voice-plugin.svg)](https://ci.appveyor.com/project/egertaia/voice-plugin)
[![Release Version](https://img.shields.io/github/release/egertaia/voice-plugin/all.svg)](https://github.com/egertaia/voice-plugin/releases)

## What is this?
This is a plugin that works with [NFive](https://github.com/NFive/NFive) which is complete plugin framework for GTAV [FiveM](https://fivem.net/).
The whole server is built and managed entirely in C#.
This project aims to help in vizualising the voice in GTAV.

### Usage
1. Make sure you are using [nfpm](https://github.com/NFive/nfpm) installed.

2. Make sure you have your project installed in a seperate folder using `nfpm setup`.

3. Install this plugin by calling `nfpm install egertaia/voice-plugin`

4. Configure this if you are not happy with default configuration. This can be done by
   * config file `path-to-server\resources\nfive\config\egertaia\voice-plugin`
   
   * style/html file `path-to-server\resources\nfive\plugins\egertaia\voice-plugin\Overlays`
   
#### Configuration
*`whisper_text` = Text for the whisper (shortest)

*`whisper_distance` = Distance that the players should hear you from.

*`normal_text` = Text for the normal (average)

*`normal_distance` = Distance that the players should hear you from.

*`yell_text` = Text for the yell (furthest)

*`yell_distance` = Distance that the players should hear you from.

*`default_text_color` = Text color that should be when user is not talking (PS! Don't forget #)

*`activated_text_color` = Text color that should be when user is talking (PS! Don't forget #)


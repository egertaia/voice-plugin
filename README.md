# Voice Plugin for NFIVE
[![License](https://img.shields.io/github/license/egertaia/voice-plugin.svg)](LICENSE)
[![Build Status](https://img.shields.io/appveyor/ci/egertaia/voice-plugin.svg)](https://ci.appveyor.com/project/egertaia/voice-plugin)
[![Release Version](https://img.shields.io/github/release/egertaia/voice-plugin/all.svg)](https://github.com/egertaia/voice-plugin/releases)

This plugin adds customizable HUD element to display the voice levels and currently talking indicator to your [NFive](https://github.com/NFive) [FiveM](https://fivem.net/) GTAV server.

This project aims to help in vizualising the voice in GTAV.

Works well with my other plugin [Street positions](https://github.com/egertaia/street-position)

![Screenshot](https://user-images.githubusercontent.com/9960794/50451277-bbccea80-093b-11e9-831c-bfaf937dace6.png)

## Installation
Install the plugin into your server from the [NFive Hub](https://hub.nfive.io/egertaia/voice-plugin): `nfpm install egertaia/voice-plugin`

## Configuration
```yml
# PS! Currently button(s) to switch between different styles and also different style count is not configurable. It defaults to Shift + H and 3.

whisper:
  text: Whisper # Text to show
  distance: 1.5 # Distance
normal:
  text: Normal
  distance: 10
yell:
  text: Yell
  distance: 25
text:
  default_color: '#fff' #Default text color when nothing is pressed; voice is inactive
  activated_color: '#76AEC7' #Activated text color; when user is pressing voice button and is speaking

# (Optional) The RPC event which when fired should start this plugin
# If set, this plugin won't display anything until after this event has fired once
# This can be used to enable this plugin once you are loaded into the game
# Defaults to disabled
activation_event: something:game:started

```
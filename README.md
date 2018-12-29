# Voice Proximity NFive Plugin
[![License](https://img.shields.io/github/license/egertaia/voice-proximity.svg)](LICENSE)
[![Build Status](https://img.shields.io/appveyor/ci/egertaia/voice-proximity.svg)](https://ci.appveyor.com/project/egertaia/voice-proximity)
[![Release Version](https://img.shields.io/github/release/egertaia/voice-proximity/all.svg)](https://github.com/egertaia/voice-proximity/releases)

This plugin adds customizable HUD element to display the voice levels and currently talking indicator to your [NFive](https://github.com/NFive) [FiveM](https://fivem.net/) GTAV server.

This project aims to help in vizualising the voice in GTAV.

Works well with my [street position](https://github.com/egertaia/street-position) plugin.

![Screenshot](https://user-images.githubusercontent.com/9960794/50451277-bbccea80-093b-11e9-831c-bfaf937dace6.png)

## Installation
Install the plugin into your server from the [NFive Hub](https://hub.nfive.io/egertaia/voice-proximity): `nfpm install egertaia/voice-proximity`

## Configuration
* For Cycle configuration please refer to [Controls](https://docs.fivem.net/game-references/controls/) and [InputModifiers](https://github.com/NFive/SDK.Client/blob/master/Input/InputModifier.cs) to find the perfect combination for you.
```yml
# Distance levels to cycle between
levels:
- name: Whisper # Name to display
  distance: 1.5 # Talk distance
- name: Normal
  distance: 10
- name: Yell
  distance: 25

# Hotkey to cycle between the levels
hotkey:
  key: 74 # Default is set to H
  modifier: 4 # Default is set to Shift

# (Optional) The RPC event which when fired should start this plugin
# If set, this plugin won't display anything until after this event has fired once
# This can be used to enable this plugin once you are loaded into the game
# Defaults to disabled
activation_event: something:game:started
```

# Changelog

## 1.0.0

- Initial release.

## 1.0.1

- Added a `.paused` variable to the `FirstPersonController` script.
- Added a `CursorController` script.

## 1.0.2

- Made the `lookSpeed` and `movementSpeed` variables public.

## 1.0.3

- Added `ResetPosition()` and `Teleport()` method.

## 1.0.4

- Added `ResetRotation()` method.

## 1.0.5

- Fixed yaw with ResetRotation method.

## 1.0.6

- Fixed issue causing fall speed to accumulate over time, resulting in incredibly fast falls.
- Fixed a bug in the `JumpForce` setter.

## 1.0.7

- Exposed `Eyes` and `Body` properties on FirstPersonController
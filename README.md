# unity-first-person-controller

Please see the [readme](Packages/com.dss.first-person-controller/README.md) in the package directory for information on all of the included scripts.

## How To Install

The first-person-controller package uses the [scoped registry](https://docs.unity3d.com/Manual/upm-scoped.html) feature to import
dependent packages. Please add the following sections to the package manifest
file (`Packages/manifest.json`).

To the `scopedRegistries` section:

```
{
  "name": "DSS",
  "url": "https://registry.npmjs.com",
  "scopes": [ "com.dss" ]
}
```

To the `dependencies` section:

```
"com.dss.first-person-controller": "1.0.5"
```

After changes, the manifest file should look like below:

```
{
  "scopedRegistries": [
    {
      "name": "DSS",
      "url": "https://registry.npmjs.com",
      "scopes": [ "com.dss" ]
    }
  ],
  "dependencies": {
    "com.dss.first-person-controller": "1.0.5",
    ...
```
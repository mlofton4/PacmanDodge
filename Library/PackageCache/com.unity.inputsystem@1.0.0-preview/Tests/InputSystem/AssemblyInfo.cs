using System.Reflection;
using System.Runtime.CompilerServices;

// Keep this in sync with "Packages/com.unity.inputsystem/package.json".
// NOTE: Unfortunately, System.Version doesn't use semantic versioning so we can't include
//       "-preview" suffixes here.
[assembly: AssemblyVersion("0.9.6")]
[assembly: InternalsVisibleTo("Unity.InputSystem.Tests.Editor")]
[assembly: InternalsVisibleTo("Unity.InputSystem.Tests")]

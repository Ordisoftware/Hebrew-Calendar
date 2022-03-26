// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.

[assembly: SuppressMessage("Critical Code Smell", "S1699:Constructors should only call non-overridable methods", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Critical Code Smell", "S2365:Properties should not make collection or array copies", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Critical Code Smell", "S2696:Instance members should not write to \"static\" fields", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Critical Code Smell", "S3973:A conditionally executed single line should be denoted by indentation", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Info Code Smell", "S1135:Track uses of \"TODO\" tags", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S1066:Collapsible \"if\" statements should be merged", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S108:Nested blocks of code should not be left empty", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S1121:Assignments should not be made from within sub-expressions", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S1854:Unused assignments should be removed", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S3928:Parameter names used into ArgumentException constructors should match an existing one ", Justification = "Irrelevant?", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S4220:Events should have proper arguments", Justification = "Irrelevant?", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Minor Code Smell", "S2486:Generic exceptions should not be ignored", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Minor Code Smell", "S3963:\"static\" fields should be initialized inline", Justification = "Opinion", Scope = "module")]

[assembly: SuppressMessage("Style", "IDE0008:Utiliser un type explicite", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Style", "IDE0011:Ajouter des accolades", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Style", "IDE0062:Rendre la fonction locale 'static'", Justification = "Less optimized proc call", Scope = "module")]

[assembly: SuppressMessage("Design", "RCS1225:Make class sealed.", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Maintainability", "RCS1139:Add summary element to documentation comment.", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Maintainability", "RCS1141:Add 'param' element to documentation comment.", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Performance", "RCS1096:Convert 'HasFlag' call to bitwise operation (or vice versa).", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Readability", "RCS1018:Add accessibility modifiers (or vice versa).", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Readability", "RCS1123:Add parentheses when necessary.", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Redundancy", "RCS1036:Remove redundant empty line.", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Simplification", "RCS1061:Merge 'if' with nested 'if'.", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Style", "RCS1001:Add braces (when expression spans over multiple lines).", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Style", "RCS1003:Add braces to if-else (when expression spans over multiple lines).", Justification = "Opinion", Scope = "module")]

[assembly: SuppressMessage("Security", "SCS0001:Potential Command Injection vulnerability was found where '{0}' in '{1}' may be tainted by user-controlled data from '{2}' in method '{3}'.", Justification = "N/A for MeteoBlue.com URL as used", Scope = "member", Target = "~M:Ordisoftware.Core.SystemManager.RunShell(System.String,System.String,System.Boolean,System.Diagnostics.ProcessWindowStyle)~System.Diagnostics.Process")]

[assembly: SuppressMessage("Performance", "U2U1002:Method can be declared static", Justification = "Can be opinion or anti-pattern (analyzer may be improved)", Scope = "module")]
[assembly: SuppressMessage("Performance", "U2U1010:Internal leaf classes can be sealed", Justification = "Can be opinion", Scope = "module")]
[assembly: SuppressMessage("Performance", "U2U1201:Local collections should be initialized with capacity", Justification = "Can be opinion", Scope = "module")]

[assembly: SuppressMessage("Performance", "CA1822:Marquer les membres comme étant static", Justification = "Opinion", Scope = "module")]

[assembly: SuppressMessage("Design", "MA0012:Do not raise reserved exception type", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0016:Prefer returning collection abstraction instead of implementation", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0018:Do not declare static members on generic types", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0026:Fix TODO comment", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0038:Make method static", Justification = "Opinion based and can reduce performances", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0041:Make property static", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0046:Use EventHandler<T> to declare events", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0048:File name must match type name", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0053:Make class sealed", Justification = "Can be opinion", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0056:Do not call overridable members in constructor", Justification = "N/A", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0076:Do not use implicit culture-sensitive ToString in interpolated strings", Justification = "<En attente>", Scope = "module")]
[assembly: SuppressMessage("Style", "MA0003:Add parameter name to improve readability", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Style", "MA0007:Add a comma after the last value", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Style", "MA0071:Avoid using redundant else", Justification = "Opinion", Scope = "module")]
[assembly: SuppressMessage("Usage", "MA0091:Sender should be 'this' for instance events", Justification = "N/A", Scope = "module")]

[assembly: SuppressMessage("CodeSmell", "EPC12:Suspicious exception handling: only Message property is observed in exception block.", Justification = "Opinion based or N/A", Scope = "module")]

[assembly: SuppressMessage("CodeSmell", "ERP022:Unobserved exception in generic exception handler", Justification = "Opinion", Scope = "module")]

[assembly: SuppressMessage("PropertyChangedAnalyzers.PropertyChanged", "INPC001:The class has mutable properties and should implement INotifyPropertyChanged.", Justification = "Opinion", Scope = "module")]





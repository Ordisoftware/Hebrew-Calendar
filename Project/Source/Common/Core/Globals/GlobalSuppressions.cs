// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.

// Analyzer ennisdoomen/CSharpGuidelines dramatically slow down VS, build and run...
//[assembly: SuppressMessage("Class Design", "AV1000:Type name contains the word 'and', which suggests it has multiple purposes", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Class Design", "AV1008:Class should not be static", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Documentation", "AV2305:Missing XML comment for internally visible type, member or parameter", Justification = "N/A")]
//[assembly: SuppressMessage("Documentation", "AV2318:Work-tracking TODO comment should be removed", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Framework", "AV2220:Simple query should be replaced by extension method call", Justification = "N/A")]
//[assembly: SuppressMessage("Layout", "AV2407:Region should be removed", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Maintainability", "AV1500:Member or local function contains too many statements", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Maintainability", "AV1505:Namespace should match with assembly name", Justification = "<En attente>")]
//[assembly: SuppressMessage("Maintainability", "AV1507:File contains multiple types", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Maintainability", "AV1532:Loop statement contains nested loop", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Maintainability", "AV1535:Missing block in case or default clause of switch statement", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Maintainability", "AV1537:If-else-if construct should end with an unconditional else clause", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Maintainability", "AV1551:Method overload should call another overload", Justification = "N/A", Scope = "module")]
//[assembly: SuppressMessage("Maintainability", "AV1562:Do not declare a parameter as ref or out", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Maintainability", "AV1564:Parameter in public or internal member is of type bool or bool?", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Maintainability", "AV1568:Parameter value should not be overwritten in method body", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Maintainability", "AV1580:Method argument calls a nested method", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Member Design", "AV1115:Member or local function contains the word 'and', which suggests doing multiple things", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Miscellaneous Design", "AV1210:Catch a specific exception instead of Exception, SystemException or ApplicationException", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Miscellaneous Design", "AV1225:Method that raises an event should be protected virtual and be named 'On' followed by event name", Justification = "<En attente>")]
//[assembly: SuppressMessage("Naming", "AV1704:Identifier contains one or more digits in its name", Justification = "N/A")]
//[assembly: SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Naming", "AV1708:Type name contains term that should be avoided", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Naming", "AV1710:Member name includes the name of its containing type", Justification = "N/A")]
//[assembly: SuppressMessage("Naming", "AV1738:Event handlers should be named according to the pattern '(InstanceName)On(EventName)'", Justification = "Opinion based", Scope = "module")]
//[assembly: SuppressMessage("Naming", "AV1745:Name of extension method container class should end with 'Extensions'", Justification = "Opinion based", Scope = "module")]

[assembly: SuppressMessage("Critical Code Smell", "S1699:Constructors should only call non-overridable methods", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Critical Code Smell", "S2365:Properties should not make collection or array copies", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Critical Code Smell", "S2696:Instance members should not write to \"static\" fields", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Critical Code Smell", "S3973:A conditionally executed single line should be denoted by indentation", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Info Code Smell", "S1135:Track uses of \"TODO\" tags", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S1066:Collapsible \"if\" statements should be merged", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S108:Nested blocks of code should not be left empty", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S1121:Assignments should not be made from within sub-expressions", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S1854:Unused assignments should be removed", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S3928:Parameter names used into ArgumentException constructors should match an existing one ", Justification = "Irrelevant?", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S4220:Events should have proper arguments", Justification = "Irrelevant?", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Minor Code Smell", "S2486:Generic exceptions should not be ignored", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Minor Code Smell", "S3963:\"static\" fields should be initialized inline", Justification = "Opinion based", Scope = "module")]

[assembly: SuppressMessage("Style", "IDE0008:Utiliser un type explicite", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Style", "IDE0011:Ajouter des accolades", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Style", "IDE0062:Rendre la fonction locale 'static'", Justification = "Less optimized proc call", Scope = "module")]

[assembly: SuppressMessage("Design", "RCS1225:Make class sealed.", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Maintainability", "RCS1139:Add summary element to documentation comment.", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Maintainability", "RCS1141:Add 'param' element to documentation comment.", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Performance", "RCS1096:Convert 'HasFlag' call to bitwise operation (or vice versa).", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Readability", "RCS1018:Add accessibility modifiers (or vice versa).", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Readability", "RCS1123:Add parentheses when necessary.", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Redundancy", "RCS1036:Remove redundant empty line.", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Simplification", "RCS1061:Merge 'if' with nested 'if'.", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Style", "RCS1001:Add braces (when expression spans over multiple lines).", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Style", "RCS1003:Add braces to if-else (when expression spans over multiple lines).", Justification = "Opinion based", Scope = "module")]

[assembly: SuppressMessage("Security", "SCS0001:Potential Command Injection vulnerability was found where '{0}' in '{1}' may be tainted by user-controlled data from '{2}' in method '{3}'.", Justification = "N/A for MeteoBlue.com URL as used", Scope = "member", Target = "~M:Ordisoftware.Core.SystemManager.RunShell(System.String,System.String,System.Boolean,System.Diagnostics.ProcessWindowStyle)~System.Diagnostics.Process")]

[assembly: SuppressMessage("Performance", "U2U1002:Method can be declared static", Justification = "Can be opinion or anti-pattern (analyzer may be improved)", Scope = "module")]
[assembly: SuppressMessage("Performance", "U2U1010:Internal leaf classes can be sealed", Justification = "Can be opinion", Scope = "module")]
[assembly: SuppressMessage("Performance", "U2U1201:Local collections should be initialized with capacity", Justification = "Can be opinion", Scope = "module")]

[assembly: SuppressMessage("Performance", "CA1822:Marquer les membres comme étant static", Justification = "Opinion based", Scope = "module")]

[assembly: SuppressMessage("Design", "MA0018:Do not declare static members on generic types", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0026:Fix TODO comment", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0038:Make method static", Justification = "Opinion based and can reduce performances", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0041:Make property static", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0048:File name must match type name", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0053:Make class sealed", Justification = "Can be opinion", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0056:Do not call overridable members in constructor", Justification = "N/A", Scope = "module")]
[assembly: SuppressMessage("Design", "MA0076:Do not use implicit culture-sensitive ToString in interpolated strings", Justification = "<En attente>", Scope = "module")]
[assembly: SuppressMessage("Style", "MA0003:Add parameter name to improve readability", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Style", "MA0007:Add a comma after the last value", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Style", "MA0071:Avoid using redundant else", Justification = "Opinion based", Scope = "module")]
[assembly: SuppressMessage("Usage", "MA0091:Sender should be 'this' for instance events", Justification = "N/A", Scope = "module")]

[assembly: SuppressMessage("CodeSmell", "EPC12:Suspicious exception handling: only Message property is observed in exception block.", Justification = "Opinion based or N/A", Scope = "module")]

[assembly: SuppressMessage("CodeSmell", "ERP022:Unobserved exception in generic exception handler", Justification = "Opinion based", Scope = "module")]

[assembly: SuppressMessage("PropertyChangedAnalyzers.PropertyChanged", "INPC001:The class has mutable properties and should implement INotifyPropertyChanged.", Justification = "Opinion based", Scope = "module")]





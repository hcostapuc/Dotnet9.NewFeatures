using DotNet9Features._2___LinqStuff;
using DotNet9Features._3___Span;
using DotNet9Features._4___Json;
using DotNet9Features._5___Guid;
using DotNet9Features.FeatureSwitching;

/// Feature Switching
/// Only Enable when the property on project named RuntimeHostConfigurationOption is set true, that is good for disabling or
/// enabling part of code without building again the entire application that would be focusing more on internal variables that are more tight
/// to project itself and not so related to business if it's business just create an environment variable for that
Feature.DoTheThing();


//Linq Stuff
//1 AggregateFeature - Instead of using select+groupby in order to know the total time peer runner use aggregateBy
//2 CountByFeature - CountBy will return a dictionary with the key and the total of marathons that runner participated
LinqStuff.DoLinqStuff();


//SpanPlansDance
// Overview all time that you will be using any type (string, object, int, collections) try to see if we can replace it with ReadOnlySpan<char> cause ocupe less memory and is faster
//1 ReadOnlySpanAsKeyFeature - I feel that is for really and extremally performance string handle purpose, cause use a alternative dictionary only
// to use ReadOnlySpan<char> as key increse complexity as well the implementation itself
//2 ReadOnlyAsParamsFeature - The benefit to use ReadOnlySpan as params is that you can pass a collection of numbers without the need to create a new array
//3 ReadOnlyAsHashSetFeature - Simple representation of a hasset in readonly mode as all the other ReadOnlySpan features less memory alocation purpose

SpanPlansDance.DoSpanPlansDance();


//Json
//Now in .net 9 they remove the integration with swagger by default, if you want to use it you need to install the package, but
//they provided a feature to expose the scheme as showing on the code.
JsonStuff.FeatureSchemeAsNode();

//Guid
// Now you can create the version 7 of the GUID, this bring more performance to databases cause the guid is created sequencially
// improving indexes and searchs
GuidVersion7.GenerateGuidVersion7();

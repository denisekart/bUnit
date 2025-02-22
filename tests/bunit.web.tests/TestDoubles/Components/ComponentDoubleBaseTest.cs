#if NET5_0_OR_GREATER
namespace Bunit.TestDoubles.Components;

public class ComponentDoubleBaseTest : TestContext
{
	private class ComponentDouble<TComponent> : ComponentDoubleBase<TComponent>
		where TComponent : IComponent
	{ }

	[Theory(DisplayName = "Double captures unmatched parameters")]
	[AutoData]
	public void Test022(string attrName, string attrValue)
	{
		var cut = RenderComponent<ComponentDouble<AllTypesOfParams<string>>>((attrName, attrValue));

		cut.Instance.Parameters[attrName].ShouldBe(attrValue);
	}
}
#endif

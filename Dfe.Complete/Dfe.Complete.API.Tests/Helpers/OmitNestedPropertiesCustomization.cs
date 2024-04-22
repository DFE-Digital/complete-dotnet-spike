using AutoFixture.Kernel;
using System.Reflection;
namespace Dfe.ManageFreeSchoolProjects.API.Tests.Helpers
{
    /// <summary>
    /// Class that allows to omit nested properties when creating an object with AutoFixture
    /// This is to make sure that if we create data that is recurise it does not cause problems later
    /// Most of the time we want to create a simple object and not a complex one
    /// </summary>
    public class OmitNestedPropertiesCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new OmitNestedPropertiesSpecimenBuilder());
        }

        private class OmitNestedPropertiesSpecimenBuilder : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                var propertyInfo = request as PropertyInfo;
                if (propertyInfo == null)
                    return new NoSpecimen();

                if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string))
                    return new OmitSpecimen();

                return context.Resolve(propertyInfo.PropertyType);
            }
        }
    }
}
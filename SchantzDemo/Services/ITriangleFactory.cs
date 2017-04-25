using SchantzDemo.Domain;

namespace SchantzDemo.Services
{
    internal interface ITriangleFactory
    {
        Triangle CreateFromArray(float[] sides);
    }
}
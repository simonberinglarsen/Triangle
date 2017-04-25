using SchantzDemo.Domain;

namespace SchantzDemo.Services
{
    public interface ITriangleFactory
    {
        Triangle CreateFromArray(float[] sides);
    }
}
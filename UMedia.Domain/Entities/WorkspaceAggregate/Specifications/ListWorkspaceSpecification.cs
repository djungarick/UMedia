namespace UMedia.Domain.Entities.WorkspaceAggregate.Specifications;

public sealed class ListWorkspaceSpecification<T> : Specification<Workspace, T>
{
    public ListWorkspaceSpecification(int? skip, int? take, Expression<Func<Workspace, T>> converter)
    {
        Query.Select(converter);

        if (skip.HasValue)
            Query.Skip(skip.Value);

        if (take.HasValue)
            Query.Take(take.Value);
    }
}

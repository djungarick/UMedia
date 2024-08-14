namespace UMedia.Domain.Entities.WorkspaceAggregate.Specifications;

public sealed class ListWorkspaceSpecification<T> : Specification<Workspace, T>
{
    public ListWorkspaceSpecification(int? skip, int? take, Expression<Func<Workspace, T>> converter)
    {
        _ = Query.Select(converter);

        if (skip.HasValue)
            _ = Query.Skip(skip.Value);

        if (take.HasValue)
            _ = Query.Take(take.Value);
    }
}

namespace UMedia.Domain.Entities.WorkspaceAggregate.Specifications;

public sealed class WorkspaceIdByNameSpecification : Specification<Workspace, int>
{
    public WorkspaceIdByNameSpecification(string name)
    {
        Query.Select(_ => _.Id)
            .Where(_ => _.Name == name);
    }
}

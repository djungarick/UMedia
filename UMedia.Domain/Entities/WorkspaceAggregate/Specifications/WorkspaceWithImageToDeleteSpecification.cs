namespace UMedia.Domain.Entities.WorkspaceAggregate.Specifications;

public sealed class WorkspaceWithImageToDeleteSpecification : Specification<Workspace>
{
    public WorkspaceWithImageToDeleteSpecification(int imageToDeleteId)
    {
        _ = Query.Where(_ => _.Images.Any(_ => _.Id == imageToDeleteId));
        _ = Query.Include(_ => _.Images.AsQueryable().Where(_ => _.Id == imageToDeleteId));
    }
}

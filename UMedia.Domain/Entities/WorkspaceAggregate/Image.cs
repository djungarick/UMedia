namespace UMedia.Domain.Entities.WorkspaceAggregate;

public sealed class Image : EntityBase
{
    private Image()
    {
    }

    public string Name { get; private set; } = null!;

    public int WorkspaceId { get; private set; }

    public Workspace Workspace { get; private set; } = null!;

#pragma warning disable IDE0046 // Convert to conditional expression
    public static Result<Image> Create(string name, int workspaceId, bool isNameAndWorkspaceIdUnique)
    {
        Result nameCheckResult = CommonNameConstraints.Check(name, isNameAndWorkspaceIdUnique);
        if (!nameCheckResult.IsSuccess)
            return nameCheckResult;

        return new Image
        {
            Name = name,
            WorkspaceId = workspaceId
        };
    }
#pragma warning restore IDE0046 // Convert to conditional expression

    public Result UpdateName(string name, bool isNameAndWorkspaceIdUnique)
    {
        Result nameCheckResult = CommonNameConstraints.Check(name, isNameAndWorkspaceIdUnique);
        if (!nameCheckResult.IsSuccess)
            return nameCheckResult;

        Name = name;

        return CachedResults.Success;
    }

    public Result UpdateWorkspaceId(int workspaceId, bool isNameAndWorkspaceIdUnique)
    {
        Result nameCheckResult = CommonNameConstraints.Check(Name, isNameAndWorkspaceIdUnique);
        if (!nameCheckResult.IsSuccess)
            return nameCheckResult;

        WorkspaceId = workspaceId;

        return CachedResults.Success;
    }
}

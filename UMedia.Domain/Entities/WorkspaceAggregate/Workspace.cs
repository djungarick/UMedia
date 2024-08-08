namespace UMedia.Domain.Entities.WorkspaceAggregate;

public sealed class Workspace : EntityBase, IAggregateRoot
{
    private Workspace()
    {
    }

    public string Name { get; private set; } = null!;

    public List<Image> Images { get; private set; } = [];

    public static Result<Workspace> Create(string name, bool isNameUnique)
    {
        Result nameCheckResult = CommonNameConstraints.Check(name, isNameUnique);
        if (!nameCheckResult.IsSuccess)
            return nameCheckResult;

        return new Workspace
        {
            Name = name
        };
    }

    public Result UpdateName(string name, bool isNameUnique)
    {
        Result nameCheckResult = CommonNameConstraints.Check(name, isNameUnique);
        if (!nameCheckResult.IsSuccess)
            return nameCheckResult;

        Name = name;

        return CachedResults.Success;
    }

    public Result<Image> AddImage(string name, bool isNameAndWorkspaceIdUnique)
    {
        Result<Image> imageCreationResult = Image.Create(name, Id, isNameAndWorkspaceIdUnique);
        if (!imageCreationResult.IsSuccess)
            return imageCreationResult;

        Images.Add(imageCreationResult.Value);

        return imageCreationResult;
    }
}

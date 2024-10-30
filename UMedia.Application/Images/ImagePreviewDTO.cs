namespace UMedia.Application.Images;

public sealed record ImagePreviewDTO(int Width, int Height, string Format, IEnumerable<byte> Data);

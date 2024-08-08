using Serilog.Formatting;
using Serilog.Templates;
using Serilog.Templates.Themes;

namespace UMedia.WebAPI.Serilog;

internal static class Formatters
{
    private const string Template = """
        [{@t:yyyy-MM-dd HH:mm:ss.fffffff} {@l:u3}
        {MachineName}/{EnvironmentUserName}/{ProcessName} ({ProcessId})/{ThreadName} ({ThreadId})
        {EnvironmentName} (SourceContext: {Coalesce(SourceContext, '<none>')})
        ClientIp: {Coalesce(ClientIp, '<none>')}]
        
        {@m}
        
        Exception: {Coalesce(@x, '<none>')}
        
        ----------------------------------------------------------------------------------------------------
        
        
        """;

    public static ITextFormatter CommonFormatter { get; } = new ExpressionTemplate(Template, theme: TemplateTheme.Code);

    public static ITextFormatter CommonUncoloredFormatter { get; } = new ExpressionTemplate(Template);
}

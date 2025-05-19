using System.ComponentModel;

using System.Text.Json;

using ModelContextProtocol.Server;

namespace McpServerDotnetFormat;

[McpServerToolType]
[Description("Provides shell formatting commands for .NET projects, enabling GitHub Copilot and agent-based tools to format entire projects, individual files, directories, or apply EditorConfig and analyzer rules via the dotnet format CLI.")]
public static class DotnetFormatTool
{
	[McpServerTool]
	[Description("Provides shell command what reformats the entire .NET project using the dotnet format CLI.")]
	public static string ReFormatProject(
		[Description("Absolute path to the .NET project file (e.g. /workspace/ShoppingCart/src/ShoppingCart/ShoppingCart.csproj).")] string dotnetProjectAbsolutePath)
	{
		return JsonSerializer.Serialize(new
		{
			Type = "shell",
			Command = "dotnet",
			Arguments = $"format {dotnetProjectAbsolutePath}"
		});
	}

	[McpServerTool]
	[Description("Provides shell command what reformats a specific file in the .NET project using the dotnet format CLI. Enables targeted formatting for Copilot and agent tools.")]
	public static string ReFormatFile(
		[Description("Absolute path to the .NET project file (e.g. /workspace/ShoppingCart/src/ShoppingCart/ShoppingCart.csproj).")] string dotnetProjectAbsolutePath,
		[Description("Absolute path to the file to format (e.g. /workspace/ShoppingCart/src/ShoppingCart/Controllers/OrderController.cs).")] string csharpFileAbsolutePath,
		[Description("Absolute workspace path (or the path to the current directory set in shell, e.g. /workspace/ShoppingCart/).")] string shellCurrentDirectoryAbsolutePath)
	{
		var fileRelativePath = Path.GetRelativePath(shellCurrentDirectoryAbsolutePath, csharpFileAbsolutePath);

		return JsonSerializer.Serialize(new
		{
			Type = "shell",
			Command = "dotnet",
			Arguments = $"format {dotnetProjectAbsolutePath} --include {fileRelativePath}"
		});
	}
}

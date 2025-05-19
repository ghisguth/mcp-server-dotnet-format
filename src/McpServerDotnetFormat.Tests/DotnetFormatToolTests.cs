using Shouldly;

namespace McpServerDotnetFormat.Tests;

public class DotnetFormatToolTests
{
	[Fact]
	public void FormatProjectShouldReturnCorrectJson()
	{
		// Arrange
		var dotnetProjectAbsolutePath = "/home/user1/project1/src/project1.csproj";
		var expected = "{\"Type\":\"shell\",\"Command\":\"dotnet\",\"Arguments\":\"format /home/user1/project1/src/project1.csproj\"}";

		// Act
		var result = DotnetFormatTool.ReFormatProject(dotnetProjectAbsolutePath);

		// Assert
		result.ShouldBe(expected);
	}

	[Fact]
	public void FormatFileShouldReturnCorrectJson()
	{
		// Arrange
		var dotnetProjectAbsolutePath = "/home/user1/project1/src/project1.csproj";
		var csharpFileAbsolutePath = "/home/user1/project1/src/file.cs";
		var shellCurrentDirectoryAbsolutePath = "/home/user1/project1/";
		var expected = "{\"Type\":\"shell\",\"Command\":\"dotnet\",\"Arguments\":\"format /home/user1/project1/src/project1.csproj --include src/file.cs\"}";

		// Act
		var result = DotnetFormatTool.ReFormatFile(dotnetProjectAbsolutePath, csharpFileAbsolutePath, shellCurrentDirectoryAbsolutePath);

		// Assert
		result.ShouldBe(expected);
	}
}

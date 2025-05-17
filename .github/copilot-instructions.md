# Copilot Instructions for McpServerDotnetFormat (.NET Project)

## General Guidelines

- **Target Frameworks:**
  - The project uses net9.0 .NET target frameworks. Ensure compatibility when adding dependencies or code.

- **Project Structure:**
  - Main code is in `src/McpServerDotnetFormat/`.
  - Tests are in `src/McpServerDotnetFormat.Tests/`.

- **Coding Style:**
  - Follow C# conventions and StyleCop rules (see `stylecop.json` and `stylecop.ruleset`).
  - Use explicit access modifiers.
  - Use `var` only when the type is obvious from the right side.
  - Prefer expression-bodied members for simple properties and methods.
  - For all async methods, including test methods, always use the `Async` suffix in the method name. This is required for analyzer compliance (see VSTHRD200).
  - For single-line comments, ensure that:
    - If a single-line comment is followed by code, there should be no blank line between the comment and the code.
    - If a single-line comment is followed by another single-line comment, insert a blank line before the second comment.
    - There should never be a single-line comment with a blank line before the code it describes.
    - Example (correct):
      // comment 1
      code

      // comment 2
      code
    - Example (incorrect):
      // comment 1

      code

- **Testing:**
  - Use xUnit for unit tests.
  - Place test files in `src/McpServerDotnetFormat.Tests/` and name them with the `Tests` suffix.
  - Test coverage should include edge cases and error handling.
  - Use AAA (Arrange, Act, Assert) pattern for structuring tests.
  - Use `Shouldly` for assertions to improve readability.
  - Use `NSubstitute` for mocking dependencies in tests.
  - Use `AutoFixture` for generating test data and reducing boilerplate code.
  - Do not use underscores (`_`) in test method names. Always use descriptive names in PascalCase. For example, use `GetTransactionFilesReturnsEmptyListIfNoFilesExist` (correct), not `GetTransactionFiles_ReturnsEmptyListIfNoFilesExist` (incorrect). Test method names must never contain underscores.

- **Build & Run:**
  - Use `dotnet build` to build the solution.
  - Use `dotnet test --logger:"console;verbosity=normal" dirs.proj` from the project to run tests.
  - Use `dotnet run --project src/McpServerDotnetFormat/McpServerDotnetFormat.csproj` to run the main application.
  - For watch mode: `dotnet watch run --project src/McpServerDotnetFormat/McpServerDotnetFormat.csproj`.

- **Warnings & Analyzers:**
  - Suppress specific warnings only when necessary (e.g., CA1812 for internal classes).
  - Address all build and analyzer warnings unless explicitly suppressed.

- **Git:**
  - Commit messages should be clear and reference the reason for the change.
  - Use feature branches for significant changes.

## .editorconfig and Analyzer Rules (Enforced)

- **Indentation & Formatting:**
  - Use tabs for indentation (not spaces) in C# files. Indent size and tab width are 4.
  - All files must end with a single newline (`insert_final_newline = true`).
  - Trim trailing whitespace on save.
  - Maximum line length is 240 characters.
  - Use Linux line endings (`LF`) for C# and most text files.

- **Modifier & Member Order:**
  - Always specify explicit access modifiers (public, private, etc.).
  - Use the preferred modifier order: `public, private, protected, internal, static, extern, new, virtual, abstract, sealed, override, readonly, unsafe, volatile, async`.

- **Naming Conventions:**
  - Properties, static fields, and public/internal fields: PascalCase.
  - Private/protected fields: _camelCase (leading underscore).
  - Locals and parameters: camelCase.
  - Interfaces: IPascalCase.
  - Type parameters: TPascalCase.
  - Constants: PascalCase (not ALL_CAPS).
  - Do not use underscores in method names (see test naming rules above).

- **var Usage:**
  - Use `var` only when the type is obvious from the right side (e.g., `var stream = new FileStream(...)`).
  - Otherwise, use explicit types.

- **Expression-bodied Members:**
  - Prefer expression-bodied members for simple properties, methods, accessors, constructors, indexers, and operators.

- **Braces & Newlines:**
  - Place open braces on a new line for all blocks, including types, methods, properties, etc.
  - Place else/catch/finally on a new line.
  - New line before members in object/anonymous initializers and between query clauses.

- **Spacing:**
  - Use spaces around binary operators and after commas.
  - No space before open square brackets or before semicolons.
  - No space between method name and opening parenthesis.

- **Other Style Rules:**
  - Prefer object/collection initializers, inferred tuple/anonymous type names, null propagation, coalesce, and pattern matching where appropriate.
  - Prefer auto-properties and compound assignments.
  - Prefer simplified boolean expressions and conditional expressions.
  - Use file-scoped namespaces.

- **Suppressions & Overrides:**
  - Some StyleCop/FxCop rules are disabled or overridden for compatibility (see .editorconfig for details).
  - For tests, async/await is preferred for readability, and some analyzer warnings are relaxed.

- **Reference:**
  - For full details, see `.editorconfig` in the repo root. These rules are enforced by analyzers and StyleCop during build and CI.

---

- Keep dependencies up to date in `Directory.Packages.props`.
- Use `global.json` to pin the .NET SDK version if needed.
- Document public APIs and important internal logic with XML comments.
- Review and update these instructions as the project evolves.

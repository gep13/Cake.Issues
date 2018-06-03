﻿namespace Cake.Issues.Tests
{
    using System;
    using Cake.Testing;
    using Shouldly;
    using Testing;
    using Xunit;

    public sealed class IssueBuilderTests
    {
        public sealed class TheNewIssueMethod
        {
            [Fact]
            public void Should_Throw_If_Message_Is_Null()
            {
                // Given
                string message = null;
                var providerType = "ProviderType";
                var providerName = "ProviderName";

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, providerType, providerName));

                // Then
                result.IsArgumentNullException("message");
            }

            [Fact]
            public void Should_Throw_If_Message_Is_Empty()
            {
                // Given
                var message = string.Empty;
                var providerType = "ProviderType";
                var providerName = "ProviderName";

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, providerType, providerName));

                // Then
                result.IsArgumentOutOfRangeException("message");
            }

            [Fact]
            public void Should_Throw_If_Message_Is_WhiteSpace()
            {
                // Given
                var message = " ";
                var providerType = "ProviderType";
                var providerName = "ProviderName";

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, providerType, providerName));

                // Then
                result.IsArgumentOutOfRangeException("message");
            }

            [Fact]
            public void Should_Throw_If_ProviderType_Is_Null()
            {
                // Given
                var message = "Message";
                string providerType = null;
                var providerName = "ProviderName";

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, providerType, providerName));

                // Then
                result.IsArgumentNullException("providerType");
            }

            [Fact]
            public void Should_Throw_If_ProviderType_Is_Empty()
            {
                // Given
                var message = "Message";
                var providerType = string.Empty;
                var providerName = "ProviderName";

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, providerType, providerName));

                // Then
                result.IsArgumentOutOfRangeException("providerType");
            }

            [Fact]
            public void Should_Throw_If_ProviderType_Is_WhiteSpace()
            {
                // Given
                var message = "Message";
                var providerType = " ";
                var providerName = "ProviderName";

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, providerType, providerName));

                // Then
                result.IsArgumentOutOfRangeException("providerType");
            }

            [Fact]
            public void Should_Throw_If_ProviderName_Is_Null()
            {
                // Given
                var message = "Message";
                var providerType = "ProviderType";
                string providerName = null;

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, providerType, providerName));

                // Then
                result.IsArgumentNullException("providerName");
            }

            [Fact]
            public void Should_Throw_If_ProviderName_Is_Empty()
            {
                // Given
                var message = "Message";
                var providerType = "ProviderType";
                var providerName = string.Empty;

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, providerType, providerName));

                // Then
                result.IsArgumentOutOfRangeException("providerName");
            }

            [Fact]
            public void Should_Throw_If_ProviderName_Is_WhiteSpace()
            {
                // Given
                var message = "Message";
                var providerType = "ProviderType";
                var providerName = " ";

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, providerType, providerName));

                // Then
                result.IsArgumentOutOfRangeException("providerName");
            }
        }

        public sealed class TheNewIssueOfTMethod
        {
            [Fact]
            public void Should_Throw_If_Message_Is_Null()
            {
                // Given
                string message = null;
                var issueProvider = new FakeIssueProvider(new FakeLog());

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, issueProvider));

                // Then
                result.IsArgumentNullException("message");
            }

            [Fact]
            public void Should_Throw_If_Message_Is_Empty()
            {
                // Given
                var message = string.Empty;
                var issueProvider = new FakeIssueProvider(new FakeLog());

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, issueProvider));

                // Then
                result.IsArgumentOutOfRangeException("message");
            }

            [Fact]
            public void Should_Throw_If_Message_Is_WhiteSpace()
            {
                // Given
                var message = " ";
                var issueProvider = new FakeIssueProvider(new FakeLog());

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, issueProvider));

                // Then
                result.IsArgumentOutOfRangeException("message");
            }

            [Fact]
            public void Should_Throw_If_IssueProvider_Is_Null()
            {
                // Given
                var message = "Message";
                IIssueProvider issueProvider = null;

                // When
                var result = Record.Exception(() =>
                    IssueBuilder.NewIssue(message, issueProvider));

                // Then
                result.IsArgumentNullException("issueProvider");
            }
        }

        public sealed class TheInProjectMethod
        {
            [Fact]
            public void Should_Handle_Projects_Which_Are_Null()
            {
                // Given
                var fixture = new IssueBuilderFixture();
                string project = null;

                // When
                var issue = fixture.IssueBuilder.InProject(project).Create();

                // Then
                issue.Project.ShouldBe(project);
            }

            [Fact]
            public void Should_Handle_Projects_Which_Are_Empty()
            {
                // Given
                var fixture = new IssueBuilderFixture();
                var project = string.Empty;

                // When
                var issue = fixture.IssueBuilder.InProject(project).Create();

                // Then
                issue.Project.ShouldBe(project);
            }

            [Fact]
            public void Should_Handle_Projects_Which_Are_WhiteSpace()
            {
                // Given
                var fixture = new IssueBuilderFixture();
                var project = " ";

                // When
                var issue = fixture.IssueBuilder.InProject(project).Create();

                // Then
                issue.Project.ShouldBe(project);
            }

            [Theory]
            [InlineData("project")]
            public void Should_Set_Project(string project)
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.InProject(project).Create();

                // Then
                issue.Project.ShouldBe(project);
            }
        }

        public sealed class TheInFileMethod
        {
            [Fact]
            public void Should_Handle_File_Paths_Which_Are_Null()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.InFile(null).Create();

                // Then
                issue.AffectedFileRelativePath.ShouldBe(null);
            }

            [Fact]
            public void Should_Handle_File_Paths_Which_Are_Empty()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.InFile(string.Empty).Create();

                // Then
                issue.AffectedFileRelativePath.ShouldBe(null);
            }

            [Fact]
            public void Should_Handle_File_Paths_Which_Are_WhiteSpace()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.InFile(" ").Create();

                // Then
                issue.AffectedFileRelativePath.ShouldBe(null);
            }

            [Theory]
            [InlineData(@"foo", @"foo")]
            [InlineData(@"foo\bar", @"foo/bar")]
            [InlineData(@"foo/bar", @"foo/bar")]
            [InlineData(@"foo\bar\", @"foo/bar")]
            [InlineData(@"foo/bar/", @"foo/bar")]
            [InlineData(@".\foo", @"foo")]
            [InlineData(@"./foo", @"foo")]
            [InlineData(@"foo\..\bar", @"foo/../bar")]
            [InlineData(@"foo/../bar", @"foo/../bar")]
            public void Should_Set_FilePath(string filePath, string expectedFilePath)
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.InFile(filePath).Create();

                // Then
                issue.AffectedFileRelativePath.ToString().ShouldBe(expectedFilePath);
                issue.AffectedFileRelativePath.IsRelative.ShouldBe(true, "File path was not set as relative.");
            }
        }

        public sealed class TheInFileLineMethod
        {
            [Fact]
            public void Should_Handle_File_Paths_Which_Are_Null()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.InFile(null).Create();

                // Then
                issue.AffectedFileRelativePath.ShouldBe(null);
            }

            [Fact]
            public void Should_Handle_File_Paths_Which_Are_Empty()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.InFile(string.Empty).Create();

                // Then
                issue.AffectedFileRelativePath.ShouldBe(null);
            }

            [Fact]
            public void Should_Handle_File_Paths_Which_Are_WhiteSpace()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.InFile(" ").Create();

                // Then
                issue.AffectedFileRelativePath.ShouldBe(null);
            }

            [Fact]
            public void Should_Throw_If_Line_Is_Negative()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.InFile("foo", -1));

                // Then
                result.IsArgumentOutOfRangeException("line");
            }

            [Fact]
            public void Should_Throw_If_Line_Is_Zero()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.InFile("foo", 0));

                // Then
                result.IsArgumentOutOfRangeException("line");
            }

            [Fact]
            public void Should_Handle_Line_Which_Is_Null()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.InFile("foo", null).Create();

                // Then
                issue.Line.ShouldBe(null);
            }

            [Theory]
            [InlineData(@"foo", @"foo")]
            [InlineData(@"foo\bar", @"foo/bar")]
            [InlineData(@"foo/bar", @"foo/bar")]
            [InlineData(@"foo\bar\", @"foo/bar")]
            [InlineData(@"foo/bar/", @"foo/bar")]
            [InlineData(@".\foo", @"foo")]
            [InlineData(@"./foo", @"foo")]
            [InlineData(@"foo\..\bar", @"foo/../bar")]
            [InlineData(@"foo/../bar", @"foo/../bar")]
            public void Should_Set_FilePath(string filePath, string expectedFilePath)
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.InFile(filePath, 10).Create();

                // Then
                issue.AffectedFileRelativePath.ToString().ShouldBe(expectedFilePath);
                issue.AffectedFileRelativePath.IsRelative.ShouldBe(true, "File path was not set as relative.");
            }

            [Theory]
            [InlineData(1)]
            [InlineData(int.MaxValue)]
            public void Should_Set_Line(int line)
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.InFile("foo", line).Create();

                // Then
                issue.Line.ShouldBe(line);
            }
        }

        public sealed class TheWithPriorityMethod
        {
            [Fact]
            public void Should_Throw_If_Name_Is_Null()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.WithPriority(0, null));

                // Then
                result.IsArgumentNullException("name");
            }

            [Fact]
            public void Should_Throw_If_Name_Is_Empty()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.WithPriority(0, string.Empty));

                // Then
                result.IsArgumentOutOfRangeException("name");
            }

            [Fact]
            public void Should_Throw_If_Name_Is_WhiteSpace()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.WithPriority(0, " "));

                // Then
                result.IsArgumentOutOfRangeException("name");
            }

            [Theory]
            [InlineData(int.MinValue)]
            [InlineData(-1)]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(int.MaxValue)]
            public void Should_Set_Priority(int priority)
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.WithPriority(priority, "Foo").Create();

                // Then
                issue.Priority.ShouldBe(priority);
            }

            [Theory]
            [InlineData("Warning")]
            public void Should_Set_PriorityName(string priorityName)
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.WithPriority(0, priorityName).Create();

                // Then
                issue.PriorityName.ShouldBe(priorityName);
            }
        }

        public sealed class TheWithPriorityEnumMethod
        {
            [Theory]
            [InlineData(IssuePriority.Hint, 100, "Hint")]
            [InlineData(IssuePriority.Suggestion, 200, "Suggestion")]
            [InlineData(IssuePriority.Warning, 300, "Warning")]
            [InlineData(IssuePriority.Error, 400, "Error")]
            public void Should_Set_Priority(IssuePriority issuePriority, int expectedPriority, string expectedPriorityName)
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.WithPriority(issuePriority).Create();

                // Then
                issue.Priority.ShouldBe(expectedPriority);
                issue.PriorityName.ShouldBe(expectedPriorityName);
            }
        }

        public sealed class TheOfRuleMethod
        {
            [Fact]
            public void Should_Throw_If_Name_Is_Null()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.OfRule(null));

                // Then
                result.IsArgumentNullException("name");
            }

            [Fact]
            public void Should_Throw_If_Name_Is_Empty()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.OfRule(string.Empty));

                // Then
                result.IsArgumentOutOfRangeException("name");
            }

            [Fact]
            public void Should_Throw_If_Name_Is_WhiteSpace()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.OfRule(" "));

                // Then
                result.IsArgumentOutOfRangeException("name");
            }

            [Theory]
            [InlineData("rule")]
            public void Should_Set_Rule(string rule)
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.OfRule(rule).Create();

                // Then
                issue.Rule.ShouldBe(rule);
            }
        }

        public sealed class TheOfRuleWithUriMethod
        {
            [Fact]
            public void Should_Throw_If_Name_Is_Null()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.OfRule(null, new Uri("https://google.com")));

                // Then
                result.IsArgumentNullException("name");
            }

            [Fact]
            public void Should_Throw_If_Name_Is_Empty()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.OfRule(string.Empty, new Uri("https://google.com")));

                // Then
                result.IsArgumentOutOfRangeException("name");
            }

            [Fact]
            public void Should_Throw_If_Name_Is_WhiteSpace()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.OfRule(" ", new Uri("https://google.com")));

                // Then
                result.IsArgumentOutOfRangeException("name");
            }

            [Fact]
            public void Should_Throw_If_RuleUri_Is_Null()
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var result = Record.Exception(() =>
                    fixture.IssueBuilder.OfRule("Rule", null));

                // Then
                result.IsArgumentNullException("uri");
            }

            [Theory]
            [InlineData("rule")]
            public void Should_Set_Rule(string rule)
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.OfRule(rule, new Uri("https://google.com")).Create();

                // Then
                issue.Rule.ShouldBe(rule);
            }

            [Theory]
            [InlineData("https://google.com/")]
            public void Should_Set_RuleUrl(string ruleUri)
            {
                // Given
                var fixture = new IssueBuilderFixture();

                // When
                var issue = fixture.IssueBuilder.OfRule("Rule", new Uri(ruleUri)).Create();

                // Then
                issue.RuleUrl.ToString().ShouldBe(ruleUri);
            }
        }
    }
}
﻿namespace Cake.Issues
{
    using System;
    using Core.IO;

    /// <summary>
    /// Base class for an issue.
    /// </summary>
    public class Issue : IIssue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Issue"/> class.
        /// </summary>
        /// <param name="filePath">The path to the file affacted by the issue.
        /// The path needs to be relative to the repository root.
        /// <c>null</c> or <see cref="string.Empty"/> if issue is not related to a change in a file.</param>
        /// <param name="line">The line in the file where the issues has occurred.
        /// <c>null</c> if the issue affects the whole file or an asssembly.</param>
        /// <param name="message">The message of the issue.</param>
        /// <param name="priority">The priority of the message.</param>
        /// <param name="rule">The rule of the issue.
        /// <c>null</c> or <see cref="string.Empty"/> if issue has no specific rule ID.</param>
        /// <param name="providerType">The type of the issue provider.</param>
        public Issue(
            string filePath,
            int? line,
            string message,
            int priority,
            string rule,
            string providerType)
            : this(filePath, line, message, priority, rule, null, providerType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Issue"/> class.
        /// </summary>
        /// <param name="filePath">The path to the file affacted by the issue.
        /// The path needs to be relative to the repository root.
        /// <c>null</c> or <see cref="string.Empty"/> if issue is not related to a change in a file.</param>
        /// <param name="line">The line in the file where the issues has occurred.
        /// <c>null</c> if the issue affects the whole file or an asssembly.</param>
        /// <param name="message">The message of the issue.</param>
        /// <param name="priority">The priority of the message.</param>
        /// <param name="rule">The rule of the issue.
        /// <c>null</c> or <see cref="string.Empty"/> if issue has no specific rule ID.</param>
        /// <param name="ruleUrl">The URL containing information about the failing rule.
        /// <c>null</c> if no URL is available.</param>
        /// <param name="providerType">The type of the issue provider.</param>
        public Issue(
            string filePath,
            int? line,
            string message,
            int priority,
            string rule,
            Uri ruleUrl,
            string providerType)
            : this(null, filePath, line, message, priority, rule, ruleUrl, providerType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Issue"/> class.
        /// </summary>
        /// <param name="project">Name of the project to which the file affected by the issue belongs.
        /// <c>null</c> or <see cref="string.Empty"/> if issue is not related to a project.</param>
        /// <param name="filePath">The path to the file affacted by the issue.
        /// The path needs to be relative to the repository root.
        /// <c>null</c> or <see cref="string.Empty"/> if issue is not related to a change in a file.</param>
        /// <param name="line">The line in the file where the issues has occurred.
        /// <c>null</c> if the issue affects the whole file or an asssembly.</param>
        /// <param name="message">The message of the issue.</param>
        /// <param name="priority">The priority of the message.</param>
        /// <param name="rule">The rule of the issue.
        /// <c>null</c> or <see cref="string.Empty"/> if issue has no specific rule ID.</param>
        /// <param name="providerType">The type of the issue provider.</param>
        public Issue(
            string project,
            string filePath,
            int? line,
            string message,
            int priority,
            string rule,
            string providerType)
            : this(project, filePath, line, message, priority, rule, null, providerType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Issue"/> class.
        /// </summary>
        /// <param name="project">Name of the project to which the file affected by the issue belongs.
        /// <c>null</c> or <see cref="string.Empty"/> if issue is not related to a project.</param>
        /// <param name="filePath">The path to the file affacted by the issue.
        /// The path needs to be relative to the repository root.
        /// <c>null</c> or <see cref="string.Empty"/> if issue is not related to a change in a file.</param>
        /// <param name="line">The line in the file where the issues has occurred.
        /// <c>null</c> if the issue affects the whole file or an asssembly.</param>
        /// <param name="message">The message of the issue.</param>
        /// <param name="priority">The priority of the message.</param>
        /// <param name="rule">The rule of the issue.
        /// <c>null</c> or <see cref="string.Empty"/> if issue has no specific rule ID.</param>
        /// <param name="ruleUrl">The URL containing information about the failing rule.
        /// <c>null</c> if no URL is available.</param>
        /// <param name="providerType">The type of the issue provider.</param>
        public Issue(
            string project,
            string filePath,
            int? line,
            string message,
            int priority,
            string rule,
            Uri ruleUrl,
            string providerType)
        {
            line?.NotNegativeOrZero(nameof(line));
            message.NotNullOrWhiteSpace(nameof(message));
            providerType.NotNullOrWhiteSpace(nameof(providerType));

            // File path needs to be relative to the repository root.
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                if (!filePath.IsValidPath())
                {
                    throw new ArgumentException("Invalid path", nameof(filePath));
                }

                this.AffectedFileRelativePath = filePath;

                if (!this.AffectedFileRelativePath.IsRelative)
                {
                    throw new ArgumentOutOfRangeException(nameof(filePath), "File path needs to be relative to the repository root.");
                }
            }

            if (this.AffectedFileRelativePath == null && line.HasValue)
            {
                throw new ArgumentOutOfRangeException(nameof(line), "Cannot specify a line while not specifying a file.");
            }

            this.Project = project;
            this.Line = line;
            this.Message = message;
            this.Priority = priority;
            this.Rule = rule;
            this.RuleUrl = ruleUrl;
            this.ProviderType = providerType;
        }

        /// <inheritdoc/>
        public string Project { get; }

        /// <inheritdoc/>
        public FilePath AffectedFileRelativePath { get; }

        /// <inheritdoc/>
        public int? Line { get; }

        /// <inheritdoc/>
        public string Message { get; }

        /// <inheritdoc/>
        public int Priority { get; }

        /// <inheritdoc/>
        public string Rule { get; }

        /// <inheritdoc/>
        public Uri RuleUrl { get; }

        /// <inheritdoc/>
        public string ProviderType { get; }
    }
}

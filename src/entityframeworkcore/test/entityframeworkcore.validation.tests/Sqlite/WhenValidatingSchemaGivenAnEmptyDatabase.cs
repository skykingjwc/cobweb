﻿using System;
using Aranasoft.Cobweb.EntityFrameworkCore.Validation.Tests.Support.Sqlite;
using FluentAssertions;
using NUnit.Framework;

namespace Aranasoft.Cobweb.EntityFrameworkCore.Validation.Tests.Sqlite {
    [TestFixture]
    public class WhenValidatingSchemaGivenAnEmptyDatabase : SqliteDatabaseFixture {
        protected Action ValidatingSchema { get; set; }

        [OneTimeSetUp]
        public void ConfigureContext() {
            ValidatingSchema = () =>
                GetContext().ValidateSchema(new SchemaValidationOptions{ValidateForeignKeys = false});
        }

        [Test]
        public void ItShouldThrowValidationException() {
            ValidatingSchema.Should().ThrowExactly<SchemaValidationException>();
        }

        [Test]
        public void ItShouldHaveValidationErrors() {
            ValidatingSchema.Should().Throw<SchemaValidationException>()
                            .Which.ValidationErrors
                            .Should().NotBeEmpty();
        }

        [Test]
        public void ItShouldOnlyHaveMissingTableErrors() {
            ValidatingSchema.Should().Throw<SchemaValidationException>()
                            .Which.ValidationErrors
                            .Should().OnlyContain(error => error.StartsWith("Missing table:", StringComparison.InvariantCultureIgnoreCase));
        }

        [Test]
        public void ItShouldNotHaveMissingColumnErrors() {
            ValidatingSchema.Should().Throw<SchemaValidationException>()
                            .Which.ValidationErrors
                            .Should().NotContain(error => error.StartsWith("Missing Column", StringComparison.InvariantCultureIgnoreCase));
        }

        [Test]
        public void ItShouldNotHaveMissingIndexErrors() {
            ValidatingSchema.Should().Throw<SchemaValidationException>()
                            .Which.ValidationErrors
                            .Should().NotContain(error => error.StartsWith("Missing Index", StringComparison.InvariantCultureIgnoreCase));
        }

        [Test]
        public void ItShouldNotHaveMissingForeignKeyErrors() {
            ValidatingSchema.Should().Throw<SchemaValidationException>()
                            .Which.ValidationErrors
                            .Should().NotContain(error => error.StartsWith("Missing Foreign Key", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
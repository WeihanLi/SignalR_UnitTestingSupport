﻿using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SignalR_UnitTestingSupportCommon.Services;
using SignalR_UnitTestingSupportCommon.Interfaces;

namespace SignalR_UnitTestingSupport.Hubs
{
    /// <summary>
    /// Hub unit tests base with Entity Framework Core
    /// </summary>
    public abstract class HubUnitTestsWithEF<TDbContext> : HubUnitTestsBase, IHubUnitTestsWithEF<TDbContext>
        where TDbContext : DbContext
    {
        DbMockAndInMemoryProvider<TDbContext> _dbProvider = new DbMockAndInMemoryProvider<TDbContext>();

        /// <summary>
        /// By default, pure TDbContext mock, without any setup.
        /// </summary>
        public Mock<TDbContext> DbContextMock
        {
            get
            {
                return _dbProvider.DbContextMock;
            }
        }

        /// <summary>
        /// Relational database in memory
        /// </summary>
        public TDbContext DbInMemorySqlite
        {
            get
            {
                return _dbProvider.DbInMemorySqlite;
            }
        }

        /// <summary>
        /// Database in memory (not really relational)
        /// <para>For more info: https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/in-memory </para>
        /// </summary>
        public TDbContext DbInMemory
        {
            get
            {
                return _dbProvider.DbInMemory;
            }
        }

        /// <summary>
        /// Only NUnit Should Call it. Do not call it directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SetUp]
        public void EfSetUp()
        {
            _dbProvider.SetUp();
        }

        /// <summary>
        /// Only NUnit Should Call it. Do not call it directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [TearDown]
        public void TearDownEFContexts()
        {
            _dbProvider.TearDown();
        }
    }
}

﻿// OsmSharp - OpenStreetMap (OSM) SDK
// Copyright (C) 2013 Abelshausen Ben
// 
// This file is part of OsmSharp.
// 
// OsmSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// OsmSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using OsmSharp.Collections.Tags;
using OsmSharp.Math.Geo;
using OsmSharp.Osm;
using OsmSharp.Osm.Data;
using OsmSharp.Osm.Data.Memory;
using OsmSharp.Osm.Streams;
using OsmSharp.Osm.PBF.Streams;

namespace OsmSharp.Data.Test.Unittests
{
    /// <summary>
    /// Contains common test-code for data providers storing/loading osm-data.
    /// </summary>
    public abstract class DataProviderOsmTests
    {
        /// <summary>
        /// Notifies the current provider that an empty database is expected.
        /// </summary>
        public abstract void NotifyEmptyExpected();

        /// <summary>
        /// Creates a datasource for the current provider.
        /// </summary>
        /// <returns></returns>
        public abstract IDataSourceReadOnly CreateDataSource();

        /// <summary>
        /// Creates a data stream target for the current provider.
        /// </summary>
        /// <returns></returns>
        public abstract OsmStreamTarget CreateDataStreamTarget();

        /// <summary>
        /// Tests read/writing a node.
        /// </summary>
        protected void TestNodeReadWrite()
        {
            this.NotifyEmptyExpected(); // empty test database.

            // create a test-node.
            Node node = new Node();
            node.Id = 1;
            node.Latitude = 51.0;
            node.Longitude = 4.0;

            // create a target, add the node, create a source and verify node in db.
            var target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddNode(node);
            target.Flush();
            target.Close();
            var dataSource = this.CreateDataSource();
            Node foundNode = dataSource.GetNode(1);
            ComparisonHelpers.CompareSimple(node, foundNode);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-node.
            node = new Node();
            node.Id = 1;
            node.Latitude = 51.0;
            node.Longitude = 4.0;
            node.UserName = "ben";

            // create a target, add the node, create a source and verify node in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddNode(node);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundNode = dataSource.GetNode(1);
            ComparisonHelpers.CompareSimple(node, foundNode);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-node.
            node = new Node();
            node.Id = 1;
            node.Latitude = 51.0;
            node.Longitude = 4.0;
            node.UserName = "ben";
            node.UserId = 10;

            // create a target, add the node, create a source and verify node in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddNode(node);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundNode = dataSource.GetNode(1);
            ComparisonHelpers.CompareSimple(node, foundNode);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-node.
            node = new Node();
            node.Id = 1;
            node.Latitude = 51.0;
            node.Longitude = 4.0;
            node.UserName = "ben";
            node.UserId = 10;
            node.Version = 1;

            // create a target, add the node, create a source and verify node in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddNode(node);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundNode = dataSource.GetNode(1);
            ComparisonHelpers.CompareSimple(node, foundNode);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-node.
            node = new Node();
            node.Id = 1;
            node.Latitude = 51.0;
            node.Longitude = 4.0;
            node.UserName = "ben";
            node.UserId = 10;
            node.Version = 1;
            node.Visible = true;

            // create a target, add the node, create a source and verify node in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddNode(node);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundNode = dataSource.GetNode(1);
            ComparisonHelpers.CompareSimple(node, foundNode);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-node.
            node = new Node();
            node.Id = 1;
            node.Latitude = 51.0;
            node.Longitude = 4.0;
            node.UserName = "ben";
            node.UserId = 10;
            node.Version = 1;
            node.Visible = true;
            node.TimeStamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            // create a target, add the node, create a source and verify node in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddNode(node);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundNode = dataSource.GetNode(1);
            ComparisonHelpers.CompareSimple(node, foundNode);


            this.NotifyEmptyExpected(); // empty test database.

            // create a test-node.
            node = new Node();
            node.Id = 1;
            node.Latitude = 51.0;
            node.Longitude = 4.0;
            node.UserName = "ben";
            node.UserId = 10;
            node.Version = 1;
            node.Visible = true;
            node.TimeStamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            node.Tags = new TagsCollection();
            node.Tags.Add("tag", "value");

            // create a target, add the node, create a source and verify node in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddNode(node);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundNode = dataSource.GetNode(1);
            ComparisonHelpers.CompareSimple(node, foundNode);
        }

        /// <summary>
        /// Tests read/writing a way.
        /// </summary>
        protected void TestWayReadWrite()
        {
            this.NotifyEmptyExpected(); // empty test database.

            // create a test-way.
            Way way = new Way();
            way.Id = 1;

            // create a target, add the way, create a source and verify way in db.
            var target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddWay(way);
            target.Flush();
            target.Close();
            var dataSource = this.CreateDataSource();
            Way foundWay = dataSource.GetWay(1);
            ComparisonHelpers.CompareSimple(way, foundWay);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-way.
            way = new Way();
            way.Id = 1;
            way.UserName = "ben";

            // create a target, add the way, create a source and verify way in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddWay(way);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundWay = dataSource.GetWay(1);
            ComparisonHelpers.CompareSimple(way, foundWay);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-way.
            way = new Way();
            way.Id = 1;
            way.UserName = "ben";
            way.UserId = 10;

            // create a target, add the way, create a source and verify way in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddWay(way);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundWay = dataSource.GetWay(1);
            ComparisonHelpers.CompareSimple(way, foundWay);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-way.
            way = new Way();
            way.Id = 1;
            way.UserName = "ben";
            way.UserId = 10;
            way.Version = 1;

            // create a target, add the way, create a source and verify way in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddWay(way);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundWay = dataSource.GetWay(1);
            ComparisonHelpers.CompareSimple(way, foundWay);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-way.
            way = new Way();
            way.Id = 1;
            way.UserName = "ben";
            way.UserId = 10;
            way.Version = 1;
            way.Visible = true;

            // create a target, add the way, create a source and verify way in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddWay(way);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundWay = dataSource.GetWay(1);
            ComparisonHelpers.CompareSimple(way, foundWay);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-way.
            way = new Way();
            way.Id = 1;
            way.UserName = "ben";
            way.UserId = 10;
            way.Version = 1;
            way.Visible = true;
            way.TimeStamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            // create a target, add the way, create a source and verify way in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddWay(way);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundWay = dataSource.GetWay(1);
            ComparisonHelpers.CompareSimple(way, foundWay);


            this.NotifyEmptyExpected(); // empty test database.

            // create a test-way.
            way = new Way();
            way.Id = 1;
            way.UserName = "ben";
            way.UserId = 10;
            way.Version = 1;
            way.Visible = true;
            way.TimeStamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            way.Tags = new TagsCollection();
            way.Tags.Add("tag", "value");

            // create a target, add the way, create a source and verify way in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddWay(way);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundWay = dataSource.GetWay(1);
            ComparisonHelpers.CompareSimple(way, foundWay);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-way.
            way = new Way();
            way.Id = 1;
            way.UserName = "ben";
            way.UserId = 10;
            way.Version = 1;
            way.Visible = true;
            way.TimeStamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            way.Nodes = new List<long>();
            way.Nodes.Add(1);
            way.Nodes.Add(2);
            way.Nodes.Add(3);
            way.Nodes.Add(1);

            // create a target, add the way, create a source and verify way in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddWay(way);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundWay = dataSource.GetWay(1);
            ComparisonHelpers.CompareSimple(way, foundWay);
        }

        /// <summary>
        /// Tests read/writing a relation.
        /// </summary>
        protected void TestRelationReadWrite()
        {
            this.NotifyEmptyExpected(); // empty test database.

            // create a test-relation.
            Relation relation = new Relation();
            relation.Id = 1;

            // create a target, add the relation, create a source and verify relation in db.
            var target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddRelation(relation);
            target.Flush();
            target.Close();
            var dataSource = this.CreateDataSource();
            Relation foundRelation = dataSource.GetRelation(1);
            ComparisonHelpers.CompareSimple(relation, foundRelation);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-relation.
            relation = new Relation();
            relation.Id = 1;
            relation.UserName = "ben";

            // create a target, add the relation, create a source and verify relation in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddRelation(relation);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundRelation = dataSource.GetRelation(1);
            ComparisonHelpers.CompareSimple(relation, foundRelation);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-relation.
            relation = new Relation();
            relation.Id = 1;
            relation.UserName = "ben";
            relation.UserId = 10;

            // create a target, add the relation, create a source and verify relation in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddRelation(relation);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundRelation = dataSource.GetRelation(1);
            ComparisonHelpers.CompareSimple(relation, foundRelation);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-relation.
            relation = new Relation();
            relation.Id = 1;
            relation.UserName = "ben";
            relation.UserId = 10;
            relation.Version = 1;

            // create a target, add the relation, create a source and verify relation in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddRelation(relation);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundRelation = dataSource.GetRelation(1);
            ComparisonHelpers.CompareSimple(relation, foundRelation);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-relation.
            relation = new Relation();
            relation.Id = 1;
            relation.UserName = "ben";
            relation.UserId = 10;
            relation.Version = 1;
            relation.Visible = true;

            // create a target, add the relation, create a source and verify relation in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddRelation(relation);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundRelation = dataSource.GetRelation(1);
            ComparisonHelpers.CompareSimple(relation, foundRelation);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-relation.
            relation = new Relation();
            relation.Id = 1;
            relation.UserName = "ben";
            relation.UserId = 10;
            relation.Version = 1;
            relation.Visible = true;
            relation.TimeStamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            // create a target, add the relation, create a source and verify relation in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddRelation(relation);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundRelation = dataSource.GetRelation(1);
            ComparisonHelpers.CompareSimple(relation, foundRelation);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-relation.
            relation = new Relation();
            relation.Id = 1;
            relation.UserName = "ben";
            relation.UserId = 10;
            relation.Version = 1;
            relation.Visible = true;
            relation.TimeStamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            relation.Tags = new TagsCollection();
            relation.Tags.Add("tag", "value");

            // create a target, add the relation, create a source and verify relation in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddRelation(relation);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundRelation = dataSource.GetRelation(1);
            ComparisonHelpers.CompareSimple(relation, foundRelation);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-relation.
            relation = new Relation();
            relation.Id = 1;
            relation.UserName = "ben";
            relation.UserId = 10;
            relation.Version = 1;
            relation.Visible = true;
            relation.TimeStamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            relation.Members = new List<RelationMember>();
            relation.Members.Add(new RelationMember() { MemberId = 1, MemberRole = "node1", MemberType = OsmGeoType.Node });
            relation.Members.Add(new RelationMember() { MemberId = 2, MemberRole = "node2", MemberType = OsmGeoType.Node });
            relation.Members.Add(new RelationMember() { MemberId = 1, MemberRole = "node1", MemberType = OsmGeoType.Node });
            relation.Members.Add(new RelationMember() { MemberId = 1, MemberRole = "way", MemberType = OsmGeoType.Way });

            // create a target, add the relation, create a source and verify relation in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddRelation(relation);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundRelation = dataSource.GetRelation(1);
            ComparisonHelpers.CompareSimple(relation, foundRelation);

            this.NotifyEmptyExpected(); // empty test database.

            // create a test-relation.
            relation = new Relation();
            relation.Id = 1;
            relation.UserName = "ben";
            relation.UserId = 10;
            relation.Version = 1;
            relation.Visible = true;
            relation.TimeStamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            relation.Members = new List<RelationMember>();
            relation.Members.Add(new RelationMember() { MemberId = 1, MemberRole = string.Empty, MemberType = OsmGeoType.Node });

            // create a target, add the relation, create a source and verify relation in db.
            target = this.CreateDataStreamTarget();
            target.Initialize();
            target.AddRelation(relation);
            target.Flush();
            target.Close();
            dataSource = this.CreateDataSource();
            foundRelation = dataSource.GetRelation(1);
            ComparisonHelpers.CompareSimple(relation, foundRelation);
        }

        /// <summary>
        /// Tests read/write and actual data file.
        /// </summary>
        protected void TestReadWriteData()
        {
            this.NotifyEmptyExpected(); // empty test database.

            // create the target and pull the data from the test-file into the sqlite database.
            OsmStreamTarget target = this.CreateDataStreamTarget();
            PBFOsmStreamSource source = new PBFOsmStreamSource(
                Assembly.GetExecutingAssembly().GetManifestResourceStream("OsmSharp.Data.Test.Unittests.Data.Osm.test.osm.pbf"));
            target.RegisterSource(source);
            target.Pull();

            IDataSourceReadOnly dataSource = this.CreateDataSource();
            MemoryDataSource memorySource = MemoryDataSource.CreateFrom(source);
            foreach (Node node in memorySource.GetNodes())
            {
                Node dbNode = dataSource.GetNode(node.Id.Value);
                ComparisonHelpers.CompareSimple(node, dbNode);
            }
            foreach (Way way in memorySource.GetWays())
            {
                Way dbWay = dataSource.GetWay(way.Id.Value);
                ComparisonHelpers.CompareSimple(way, dbWay);
            }
            foreach (Relation relation in memorySource.GetRelations())
            {
                Relation dbRelation = dataSource.GetRelation(relation.Id.Value);
                ComparisonHelpers.CompareSimple(relation, dbRelation);
            }
        }

        /// <summary>
        /// Tests writing data and getting ways using it's nodes.
        /// </summary>
        protected void TestGetWaysForNode()
        {
            this.NotifyEmptyExpected(); // empty test database.

            // create the target and pull the data from the test-file into the sqlite database.
            OsmStreamTarget target = this.CreateDataStreamTarget();
            target.Initialize();
            PBFOsmStreamSource source = new PBFOsmStreamSource(
                Assembly.GetExecutingAssembly().GetManifestResourceStream("OsmSharp.Data.Test.Unittests.Data.Osm.test.osm.pbf"));
            IDataSourceReadOnly dataSource = this.CreateDataSource();
            source.Initialize();
            while (source.MoveNext())
            {
                switch (source.Current().Type)
                {
                    case OsmGeoType.Way:
                        Way way = (source.Current() as Way);
                        target.AddWay(way);
                        target.Flush();

                        if (way.Nodes != null)
                        {
                            foreach (long nodeId in way.Nodes)
                            {
                                IList<Way> ways = dataSource.GetWaysFor(nodeId);
                                Assert.IsNotNull(ways);
                                Assert.IsTrue(ways.Count > 0);
                                List<Way> foundWays = new List<Way>(ways.Where<Way>(x => x.Id == way.Id));
                                Assert.AreEqual(1, foundWays.Count);
                            }
                        }
                        break;
                }
            }

            MemoryDataSource memorySource = MemoryDataSource.CreateFrom(source);
            foreach (Way way in memorySource.GetWays())
            {
                if (way.Nodes != null)
                {
                    foreach (long nodeId in way.Nodes)
                    {
                        IList<Way> ways = dataSource.GetWaysFor(nodeId);
                        Assert.IsNotNull(ways);
                        Assert.IsTrue(ways.Count > 0);
                        List<Way> foundWays = new List<Way>(ways.Where<Way>(x => x.Id == way.Id));
                        Assert.AreEqual(1, foundWays.Count);
                    }
                }
            }

        }

        /// <summary>
        /// Tests writing data and getting relations using it's members.
        /// </summary>
        protected void TestGetRelationsForMember()
        {
            this.NotifyEmptyExpected(); // empty test database.

            // create the target and pull the data from the test-file into the sqlite database.
            OsmStreamTarget target = this.CreateDataStreamTarget();
            target.Initialize();
            PBFOsmStreamSource source = new PBFOsmStreamSource(
                Assembly.GetExecutingAssembly().GetManifestResourceStream("OsmSharp.Data.Test.Unittests.Data.Osm.test.osm.pbf"));
            IDataSourceReadOnly dataSource = this.CreateDataSource();
            source.Initialize();
            while (source.MoveNext())
            {
                switch (source.Current().Type)
                {
                    case OsmGeoType.Relation:
                        Relation relation = (source.Current() as Relation);
                        target.AddRelation(relation);
                        target.Flush();

                        if (relation.Members != null)
                        {
                            foreach (var member in relation.Members)
                            {
                                OsmGeoType type = OsmGeoType.Node;
                                switch (member.MemberType.Value)
                                {
                                    case OsmGeoType.Node:
                                        type = OsmGeoType.Node;
                                        break;
                                    case OsmGeoType.Way:
                                        type = OsmGeoType.Way;
                                        break;
                                    case OsmGeoType.Relation:
                                        type = OsmGeoType.Relation;
                                        break;
                                }
                                IList<Relation> relations = dataSource.GetRelationsFor(type, member.MemberId.Value);
                                Assert.IsNotNull(relations);
                                Assert.IsTrue(relations.Count > 0);
                                List<Relation> foundRelations = new List<Relation>(relations.Where<Relation>(x => x.Id == relation.Id));
                                Assert.AreEqual(1, foundRelations.Count);
                            }
                        }
                        break;
                }
            }

            MemoryDataSource memorySource = MemoryDataSource.CreateFrom(source);
            foreach (Relation relation in memorySource.GetRelations())
            {
                if (relation.Members != null)
                {
                    foreach (var member in relation.Members)
                    {
                        OsmGeoType type = OsmGeoType.Node;
                        switch (member.MemberType.Value)
                        {
                            case OsmGeoType.Node:
                                type = OsmGeoType.Node;
                                break;
                            case OsmGeoType.Way:
                                type = OsmGeoType.Way;
                                break;
                            case OsmGeoType.Relation:
                                type = OsmGeoType.Relation;
                                break;
                        }
                        IList<Relation> relations = dataSource.GetRelationsFor(type, member.MemberId.Value);
                        Assert.IsNotNull(relations);
                        Assert.IsTrue(relations.Count > 0);
                        List<Relation> foundRelations = new List<Relation>(relations.Where<Relation>(x => x.Id == relation.Id));
                        Assert.AreEqual(1, foundRelations.Count);
                    }
                }
                break;
            }

        }
        /// <summary>
        /// Tests a few boundingbox queries.
        /// </summary>
        protected void TestBoundingBoxQueries()
        {
            this.NotifyEmptyExpected(); // empty test database.

            // create the target and pull the data from the test-file into the sqlite database.
            OsmStreamTarget target = this.CreateDataStreamTarget();
            PBFOsmStreamSource source = new PBFOsmStreamSource(
                Assembly.GetExecutingAssembly().GetManifestResourceStream("OsmSharp.Data.Test.Unittests.Data.Osm.test.osm.pbf"));
            target.RegisterSource(source);
            target.Pull();

            IDataSourceReadOnly dataSource = this.CreateDataSource();
            MemoryDataSource memorySource = MemoryDataSource.CreateFrom(source);

            // get reference data and compare to the real thing!
            GeoCoordinateBox box = memorySource.BoundingBox;
            IList<OsmGeo> referenceBoxData = memorySource.Get(box, null);
            IList<OsmGeo> boxData = dataSource.Get(box, null);
            this.CompareResults(referenceBoxData, boxData);

            // increase box size and compare again.
            box = memorySource.BoundingBox.Resize(0.1);
            referenceBoxData = memorySource.Get(box, null);
            boxData = dataSource.Get(box, null);
            this.CompareResults(referenceBoxData, boxData);

            // descrese box size and compare again.
            box = memorySource.BoundingBox.Scale(0.5);
            referenceBoxData = memorySource.Get(box, null);
            boxData = dataSource.Get(box, null);
            this.CompareResults(referenceBoxData, boxData);

            // descrese box size and compare again.
            box = memorySource.BoundingBox.Scale(0.25);
            referenceBoxData = memorySource.Get(box, null);
            boxData = dataSource.Get(box, null);
            this.CompareResults(referenceBoxData, boxData);

            // descrese box size and compare again.
            box = memorySource.BoundingBox.Scale(0.1);
            referenceBoxData = memorySource.Get(box, null);
            boxData = dataSource.Get(box, null);
            this.CompareResults(referenceBoxData, boxData);
        }

        #region Comparison Methods

        /// <summary>
        /// Compares the two collection to check if they contain the same objects.
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="found"></param>
        private void CompareResults(IList<OsmGeo> expected, IList<OsmGeo> found)
        {
            //Assert.AreEqual(expected.Count, found.Count);
            Dictionary<string, OsmGeo> referenceBoxDataIndex = new Dictionary<string, OsmGeo>();
            foreach (OsmGeo osmGeo in expected)
            {
                referenceBoxDataIndex.Add(string.Format("{0}:{1}", osmGeo.Type.ToString(), osmGeo.Id.Value), osmGeo);
            }

            foreach (OsmGeo osmGeo in found)
            {
                string refString = string.Format("{0}:{1}", osmGeo.Type.ToString(), osmGeo.Id.Value);
                OsmGeo refOsmGeo;
                if (referenceBoxDataIndex.TryGetValue(refString, out refOsmGeo))
                {
                    Assert.IsNotNull(refOsmGeo);
                    switch (osmGeo.Type)
                    {
                        case OsmGeoType.Node:
                            ComparisonHelpers.CompareSimple(refOsmGeo as Node, osmGeo as Node);
                            break;
                        case OsmGeoType.Way:
                            ComparisonHelpers.CompareSimple(refOsmGeo as Way, osmGeo as Way);
                            break;
                        case OsmGeoType.Relation:
                            ComparisonHelpers.CompareSimple(refOsmGeo as Relation, osmGeo as Relation);
                            break;
                    }
                }
                else
                {
                    Assert.Fail("Reference data not found!");
                }
            }
        }

        #endregion
    }
}

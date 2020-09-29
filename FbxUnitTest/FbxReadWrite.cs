using System;
using System.IO;
using Fbx;
using FbxUnitTest.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FbxUnitTest
{
	[TestClass]
	public class FbxReadWrite
	{
		private void TestCommon(byte[] data, bool isBinary)
		{
			// Binary
			using (var streamIn = new MemoryStream(data))
			using (var streamOut = new MemoryStream())
			using (var streamTmp = new MemoryStream())
			{
				if (isBinary)
				{
					var reader = new FbxBinaryReader(streamIn);
					var doc = reader.Read();
					FbxIO.WriteAscii(doc, streamOut);

					// read output again and ensure for correct output data
					streamOut.Position = 0;
					reader = new FbxBinaryReader(streamOut);
					FbxIO.WriteBinary(doc, streamTmp);
				}
				else
				{
					var reader = new FbxAsciiReader(streamIn);
					var doc = reader.Read();
					FbxIO.WriteAscii(doc, streamOut);

					// read output again and ensure for correct output data
					streamOut.Position = 0;
					reader = new FbxAsciiReader(streamOut);
					FbxIO.WriteAscii(doc, streamTmp);
				}
			}
		}

		[TestMethod]
		[TestCategory("Binary")]
		public void Binary2006()
		{
			TestCommon(Resources.FbxBin2006, true);
		}

		[TestMethod]
		[TestCategory("Binary")]
		public void Binary2009()
		{
			TestCommon(Resources.FbxBin2009, true);
		}

		[TestMethod]
		[TestCategory("Binary")]
		public void Binary2010()
		{
			TestCommon(Resources.FbxBin2010, true);
		}

		[TestMethod]
		[TestCategory("Binary")]
		public void Binary2011()
		{
			TestCommon(Resources.FbxBin2011, true);
		}

		[TestMethod]
		[TestCategory("Binary")]
		public void Binary2012()
		{
			TestCommon(Resources.FbxBin2012, true);
		}

		[TestMethod]
		[TestCategory("Binary")]
		public void Binary2013()
		{
			TestCommon(Resources.FbxBin2013, true);
		}

		[TestMethod]
		[TestCategory("Binary")]
		public void Binary2015()
		{
			TestCommon(Resources.FbxBin2015, true);
		}

		[TestMethod]
		[TestCategory("Binary")]
		public void Binary2016()
		{
			TestCommon(Resources.FbxBin2016, true);
		}

		[TestMethod]
		[TestCategory("Binary")]
		public void Binary2018()
		{
			TestCommon(Resources.FbxBin2018, true);
		}

		[TestMethod]
		[TestCategory("Binary")]
		public void Binary2019()
		{
			TestCommon(Resources.FbxBin2019, true);
		}

		[TestMethod]
		[TestCategory("Binary")]
		public void Binary2020()
		{
			TestCommon(Resources.FbxBin2020, true);
		}

		[TestMethod]
		[TestCategory("AscII")]
		public void AscII2006()
		{
			TestCommon(Resources.FbxAscII2006, false);
		}

		[TestMethod]
		[TestCategory("AscII")]
		public void AscII2009()
		{
			TestCommon(Resources.FbxAscII2009, false);
		}

		[TestMethod]
		[TestCategory("AscII")]
		public void AscII2010()
		{
			TestCommon(Resources.FbxAscII2010, false);
		}

		[TestMethod]
		[TestCategory("AscII")]
		public void AscII2011()
		{
			TestCommon(Resources.FbxAscII2011, false);
		}

		[TestMethod]
		[TestCategory("AscII")]
		public void AscII2012()
		{
			TestCommon(Resources.FbxAscII2012, false);
		}

		[TestMethod]
		[TestCategory("AscII")]
		public void AscII2013()
		{
			TestCommon(Resources.FbxAscII2013, false);
		}

		[TestMethod]
		[TestCategory("AscII")]
		public void AscII2015()
		{
			TestCommon(Resources.FbxAscII2015, false);
		}

		[TestMethod]
		[TestCategory("AscII")]
		public void AscII2016()
		{
			TestCommon(Resources.FbxAscII2016, false);
		}

		[TestMethod]
		[TestCategory("AscII")]
		public void AscII2018()
		{
			TestCommon(Resources.FbxAscII2018, false);
		}

		[TestMethod]
		[TestCategory("AscII")]
		public void AscII2019()
		{
			TestCommon(Resources.FbxAscII2019, false);
		}

		[TestMethod]
		[TestCategory("AscII")]
		public void AscII2020()
		{
			TestCommon(Resources.FbxAscII2020, false);
		}
	}
}

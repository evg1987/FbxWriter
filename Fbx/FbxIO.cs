﻿using System;
using System.Globalization;
using System.IO;
using System.Threading;

namespace Fbx
{
	/// <summary>
	/// Static read and write methods
	/// </summary>
	// IO is an acronym
	// ReSharper disable once InconsistentNaming
	public static class FbxIO
	{
		/// <summary>
		/// Reads a binary FBX file
		/// </summary>
		/// <param name="path"></param>
		/// <returns>The top level document node</returns>
		public static FbxDocument ReadBinary(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			using (var stream = new FileStream(path, FileMode.Open))
			{
				var reader = new FbxBinaryReader(stream);
				return reader.Read();
			}
		}

		/// <summary>
		/// Reads an ASCII FBX file
		/// </summary>
		/// <param name="path"></param>
		/// <returns>The top level document node</returns>
		public static FbxDocument ReadAscii(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			using (var stream = new FileStream(path, FileMode.Open))
			{
				var reader = new FbxAsciiReader(stream);
				return reader.Read();
			}
		}

		/// <summary>
		/// Writes an FBX document
		/// </summary>
		/// <param name="document">The top level document node</param>
		/// <param name="stream">Output stream</param>
		public static void WriteBinary(FbxDocument document, Stream stream)
		{
			var writer = new FbxBinaryWriter(stream);
			writer.Write(document);
		}

		/// <summary>
		/// Writes an FBX document
		/// </summary>
		/// <param name="document">The top level document node</param>
		/// <param name="path"></param>
		public static void WriteAscii(FbxDocument document, Stream stream)
		{
			CultureInfo cultureInfoOriginal = Thread.CurrentThread.CurrentCulture;
			try
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

				var writer = new FbxAsciiWriter(stream);
				writer.Write(document);
			}
			finally
			{
				Thread.CurrentThread.CurrentCulture = cultureInfoOriginal;
			}
		}
	}
}

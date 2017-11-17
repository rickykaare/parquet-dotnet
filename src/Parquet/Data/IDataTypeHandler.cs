﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Parquet.Data;

namespace Parquet.Data
{
   /// <summary>
   /// Prototype: data type interface
   /// </summary>
   interface IDataTypeHandler
   {
      bool IsMatch(Thrift.SchemaElement tse, ParquetOptions formatOptions);

      SchemaElement CreateSchemaElement(IList<Thrift.SchemaElement> schema, ref int index);

      int? BitWidth { get; }

      DataType DataType { get; }

      Type ClrType { get; }

      IList CreateEmptyList(bool isNullable, int capacity);

      IList Read(Thrift.SchemaElement tse, BinaryReader reader, ParquetOptions formatOptions);

      void CreateThrift(SchemaElement se, Thrift.SchemaElement parent, IList<Thrift.SchemaElement> container);

      void Write(BinaryWriter writer, IList values);
   }
}
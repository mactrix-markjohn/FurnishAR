// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace ror.schema.upload
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct GCSSignedWriteURL : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static GCSSignedWriteURL GetRootAsGCSSignedWriteURL(ByteBuffer _bb) { return GetRootAsGCSSignedWriteURL(_bb, new GCSSignedWriteURL()); }
  public static GCSSignedWriteURL GetRootAsGCSSignedWriteURL(ByteBuffer _bb, GCSSignedWriteURL obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public GCSSignedWriteURL __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public ror.schema.upload.GCSSignedAuth? WriteAuth { get { int o = __p.__offset(4); return o != 0 ? (ror.schema.upload.GCSSignedAuth?)(new ror.schema.upload.GCSSignedAuth()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }
  public ror.schema.upload.GCSSignedAuth? DeleteAuth { get { int o = __p.__offset(6); return o != 0 ? (ror.schema.upload.GCSSignedAuth?)(new ror.schema.upload.GCSSignedAuth()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }

  public static Offset<ror.schema.upload.GCSSignedWriteURL> CreateGCSSignedWriteURL(FlatBufferBuilder builder,
      Offset<ror.schema.upload.GCSSignedAuth> writeAuthOffset = default(Offset<ror.schema.upload.GCSSignedAuth>),
      Offset<ror.schema.upload.GCSSignedAuth> deleteAuthOffset = default(Offset<ror.schema.upload.GCSSignedAuth>)) {
    builder.StartTable(2);
    GCSSignedWriteURL.AddDeleteAuth(builder, deleteAuthOffset);
    GCSSignedWriteURL.AddWriteAuth(builder, writeAuthOffset);
    return GCSSignedWriteURL.EndGCSSignedWriteURL(builder);
  }

  public static void StartGCSSignedWriteURL(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddWriteAuth(FlatBufferBuilder builder, Offset<ror.schema.upload.GCSSignedAuth> writeAuthOffset) { builder.AddOffset(0, writeAuthOffset.Value, 0); }
  public static void AddDeleteAuth(FlatBufferBuilder builder, Offset<ror.schema.upload.GCSSignedAuth> deleteAuthOffset) { builder.AddOffset(1, deleteAuthOffset.Value, 0); }
  public static Offset<ror.schema.upload.GCSSignedWriteURL> EndGCSSignedWriteURL(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<ror.schema.upload.GCSSignedWriteURL>(o);
  }
  public GCSSignedWriteURLT UnPack() {
    var _o = new GCSSignedWriteURLT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(GCSSignedWriteURLT _o) {
    _o.WriteAuth = this.WriteAuth.HasValue ? this.WriteAuth.Value.UnPack() : null;
    _o.DeleteAuth = this.DeleteAuth.HasValue ? this.DeleteAuth.Value.UnPack() : null;
  }
  public static Offset<ror.schema.upload.GCSSignedWriteURL> Pack(FlatBufferBuilder builder, GCSSignedWriteURLT _o) {
    if (_o == null) return default(Offset<ror.schema.upload.GCSSignedWriteURL>);
    var _writeAuth = _o.WriteAuth == null ? default(Offset<ror.schema.upload.GCSSignedAuth>) : ror.schema.upload.GCSSignedAuth.Pack(builder, _o.WriteAuth);
    var _deleteAuth = _o.DeleteAuth == null ? default(Offset<ror.schema.upload.GCSSignedAuth>) : ror.schema.upload.GCSSignedAuth.Pack(builder, _o.DeleteAuth);
    return CreateGCSSignedWriteURL(
      builder,
      _writeAuth,
      _deleteAuth);
  }
};

public class GCSSignedWriteURLT
{
  public ror.schema.upload.GCSSignedAuthT WriteAuth { get; set; }
  public ror.schema.upload.GCSSignedAuthT DeleteAuth { get; set; }

  public GCSSignedWriteURLT() {
    this.WriteAuth = null;
    this.DeleteAuth = null;
  }
}


}

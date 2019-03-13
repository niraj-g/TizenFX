#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { namespace Filter { 
/// <summary>Evas internal implementation of filters.</summary>
[InternalNativeInherit]
public interface Internal : 
   Efl.Gfx.Filter ,
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Marks this filter as changed.</summary>
/// <param name="val"><c>true</c> if filter changed, <c>false</c> otherwise</param>
/// <returns></returns>
 void SetFilterChanged( bool val);
   /// <summary>Marks this filter as invalid.</summary>
/// <param name="val"><c>true</c> if filter is invalid, <c>false</c> otherwise</param>
/// <returns></returns>
 void SetFilterInvalid( bool val);
   /// <summary>Retrieve cached output buffer, if any.
/// Does not increment the reference count.</summary>
/// <returns>Output buffer</returns>
 System.IntPtr GetFilterOutputBuffer();
   /// <summary>Called by Efl.Canvas.Filter.Internal to determine whether the input is alpha or rgba.</summary>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool FilterInputAlpha();
   /// <summary>Called by Efl.Canvas.Filter.Internal to request the parent class for state information (color, etc...).</summary>
/// <param name="state">State info to fill in</param>
/// <param name="data">Private data for the class</param>
/// <returns></returns>
 void FilterStatePrepare( out Efl.Canvas.Filter.State state,   System.IntPtr data);
   /// <summary>Called by Efl.Canvas.Filter.Internal when the parent class must render the input.</summary>
/// <param name="filter">Current filter context</param>
/// <param name="engine">Engine context</param>
/// <param name="output">Output context</param>
/// <param name="drawctx">Draw context (for evas engine)</param>
/// <param name="data">Private data used by textblock</param>
/// <param name="l">Left</param>
/// <param name="r">Right</param>
/// <param name="t">Top</param>
/// <param name="b">Bottom</param>
/// <param name="x">X offset</param>
/// <param name="y">Y offset</param>
/// <param name="do_async"><c>true</c> when the operation should be done asynchronously, <c>false</c> otherwise</param>
/// <returns>Indicates success from the object render function.</returns>
bool FilterInputRender(  System.IntPtr filter,   System.IntPtr engine,   System.IntPtr output,   System.IntPtr drawctx,   System.IntPtr data,   int l,   int r,   int t,   int b,   int x,   int y,  bool do_async);
   /// <summary>Called when filter changes must trigger a redraw of the object.
/// Virtual, to be implemented in the parent class.</summary>
/// <returns></returns>
 void FilterDirty();
                        /// <summary>Marks this filter as changed.</summary>
/// <value><c>true</c> if filter changed, <c>false</c> otherwise</value>
   bool FilterChanged {
      set ;
   }
   /// <summary>Marks this filter as invalid.</summary>
/// <value><c>true</c> if filter is invalid, <c>false</c> otherwise</value>
   bool FilterInvalid {
      set ;
   }
   /// <summary>Retrieve cached output buffer, if any.
/// Does not increment the reference count.</summary>
/// <value>Output buffer</value>
    System.IntPtr FilterOutputBuffer {
      get ;
   }
}
/// <summary>Evas internal implementation of filters.</summary>
sealed public class InternalConcrete : 

Internal
   , Efl.Gfx.Filter
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (InternalConcrete))
            return Efl.Canvas.Filter.InternalNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_filter_internal_mixin_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public InternalConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~InternalConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static InternalConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new InternalConcrete(obj.NativeHandle);
   }
   ///<summary>Verifies if the given object is equal to this one.</summary>
   public override bool Equals(object obj)
   {
      var other = obj as Efl.Object;
      if (other == null)
         return false;
      return this.NativeHandle == other.NativeHandle;
   }
   ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
   public override int GetHashCode()
   {
      return this.NativeHandle.ToInt32();
   }
   ///<summary>Turns the native pointer into a string representation.</summary>
   public override String ToString()
   {
      return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
   }
    void register_event_proxies()
   {
   }
   /// <summary>Marks this filter as changed.</summary>
   /// <param name="val"><c>true</c> if filter changed, <c>false</c> otherwise</param>
   /// <returns></returns>
   public  void SetFilterChanged( bool val) {
                         Efl.Canvas.Filter.InternalNativeInherit.evas_filter_changed_set_ptr.Value.Delegate(this.NativeHandle, val);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Marks this filter as invalid.</summary>
   /// <param name="val"><c>true</c> if filter is invalid, <c>false</c> otherwise</param>
   /// <returns></returns>
   public  void SetFilterInvalid( bool val) {
                         Efl.Canvas.Filter.InternalNativeInherit.evas_filter_invalid_set_ptr.Value.Delegate(this.NativeHandle, val);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Retrieve cached output buffer, if any.
   /// Does not increment the reference count.</summary>
   /// <returns>Output buffer</returns>
   public  System.IntPtr GetFilterOutputBuffer() {
       var _ret_var = Efl.Canvas.Filter.InternalNativeInherit.evas_filter_output_buffer_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Called by Efl.Canvas.Filter.Internal to determine whether the input is alpha or rgba.</summary>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   public bool FilterInputAlpha() {
       var _ret_var = Efl.Canvas.Filter.InternalNativeInherit.evas_filter_input_alpha_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Called by Efl.Canvas.Filter.Internal to request the parent class for state information (color, etc...).</summary>
   /// <param name="state">State info to fill in</param>
   /// <param name="data">Private data for the class</param>
   /// <returns></returns>
   public  void FilterStatePrepare( out Efl.Canvas.Filter.State state,   System.IntPtr data) {
                   var _out_state = new Efl.Canvas.Filter.State_StructInternal();
                        Efl.Canvas.Filter.InternalNativeInherit.evas_filter_state_prepare_ptr.Value.Delegate(this.NativeHandle, out _out_state,  data);
      Eina.Error.RaiseIfUnhandledException();
      state = Efl.Canvas.Filter.State_StructConversion.ToManaged(_out_state);
                         }
   /// <summary>Called by Efl.Canvas.Filter.Internal when the parent class must render the input.</summary>
   /// <param name="filter">Current filter context</param>
   /// <param name="engine">Engine context</param>
   /// <param name="output">Output context</param>
   /// <param name="drawctx">Draw context (for evas engine)</param>
   /// <param name="data">Private data used by textblock</param>
   /// <param name="l">Left</param>
   /// <param name="r">Right</param>
   /// <param name="t">Top</param>
   /// <param name="b">Bottom</param>
   /// <param name="x">X offset</param>
   /// <param name="y">Y offset</param>
   /// <param name="do_async"><c>true</c> when the operation should be done asynchronously, <c>false</c> otherwise</param>
   /// <returns>Indicates success from the object render function.</returns>
   public bool FilterInputRender(  System.IntPtr filter,   System.IntPtr engine,   System.IntPtr output,   System.IntPtr drawctx,   System.IntPtr data,   int l,   int r,   int t,   int b,   int x,   int y,  bool do_async) {
                                                                                                                                                                                                                               var _ret_var = Efl.Canvas.Filter.InternalNativeInherit.evas_filter_input_render_ptr.Value.Delegate(this.NativeHandle, filter,  engine,  output,  drawctx,  data,  l,  r,  t,  b,  x,  y,  do_async);
      Eina.Error.RaiseIfUnhandledException();
                                                                                                                                                      return _ret_var;
 }
   /// <summary>Called when filter changes must trigger a redraw of the object.
   /// Virtual, to be implemented in the parent class.</summary>
   /// <returns></returns>
   public  void FilterDirty() {
       Efl.Canvas.Filter.InternalNativeInherit.evas_filter_dirty_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Gets the code of the filter program set on this object. May be <c>null</c>.
   /// 1.18</summary>
   /// <param name="code">The Lua program source code.
   /// 1.18</param>
   /// <param name="name">An optional name for this filter.
   /// 1.18</param>
   /// <returns></returns>
   public  void GetFilterProgram( out  System.String code,  out  System.String name) {
                                           Efl.Gfx.FilterNativeInherit.efl_gfx_filter_program_get_ptr.Value.Delegate(this.NativeHandle, out code,  out name);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Set a graphical filter program on this object.
   /// Valid for Text and Image objects at the moment.
   /// 
   /// The argument passed to this function is a string containing a valid Lua program based on the filters API as described in the &quot;EFL Graphics Filters&quot; reference page.
   /// 
   /// Set to <c>null</c> to disable filtering.
   /// 1.18</summary>
   /// <param name="code">The Lua program source code.
   /// 1.18</param>
   /// <param name="name">An optional name for this filter.
   /// 1.18</param>
   /// <returns></returns>
   public  void SetFilterProgram(  System.String code,   System.String name) {
                                           Efl.Gfx.FilterNativeInherit.efl_gfx_filter_program_set_ptr.Value.Delegate(this.NativeHandle, code,  name);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Set the current state of the filter.
   /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
   /// 
   /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.
   /// 1.18</summary>
   /// <param name="cur_state">Current state of the filter
   /// 1.18</param>
   /// <param name="cur_val">Current value
   /// 1.18</param>
   /// <param name="next_state">Next filter state, optional
   /// 1.18</param>
   /// <param name="next_val">Next value, optional
   /// 1.18</param>
   /// <param name="pos">Position, optional
   /// 1.18</param>
   /// <returns></returns>
   public  void GetFilterState( out  System.String cur_state,  out double cur_val,  out  System.String next_state,  out double next_val,  out double pos) {
                                                                                                 Efl.Gfx.FilterNativeInherit.efl_gfx_filter_state_get_ptr.Value.Delegate(this.NativeHandle, out cur_state,  out cur_val,  out next_state,  out next_val,  out pos);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }
   /// <summary>Set the current state of the filter.
   /// This should be used by Edje (EFL&apos;s internal layout engine), but could also be used when implementing animations programmatically.
   /// 
   /// A full state is defined by two states (name + value): origin state and target state of an ongoing animation, as well as the <c>pos</c> progress (from 0 to 1) of that animation timeline. The second state can be omitted if there is no ongoing animation.
   /// 1.18</summary>
   /// <param name="cur_state">Current state of the filter
   /// 1.18</param>
   /// <param name="cur_val">Current value
   /// 1.18</param>
   /// <param name="next_state">Next filter state, optional
   /// 1.18</param>
   /// <param name="next_val">Next value, optional
   /// 1.18</param>
   /// <param name="pos">Position, optional
   /// 1.18</param>
   /// <returns></returns>
   public  void SetFilterState(  System.String cur_state,  double cur_val,   System.String next_state,  double next_val,  double pos) {
                                                                                                 Efl.Gfx.FilterNativeInherit.efl_gfx_filter_state_set_ptr.Value.Delegate(this.NativeHandle, cur_state,  cur_val,  next_state,  next_val,  pos);
      Eina.Error.RaiseIfUnhandledException();
                                                                   }
   /// <summary>Gets the padding required to apply this filter.
   /// 1.18</summary>
   /// <param name="l">Padding on the left
   /// 1.18</param>
   /// <param name="r">Padding on the right
   /// 1.18</param>
   /// <param name="t">Padding on the top
   /// 1.18</param>
   /// <param name="b">Padding on the bottom
   /// 1.18</param>
   /// <returns></returns>
   public  void GetFilterPadding( out  int l,  out  int r,  out  int t,  out  int b) {
                                                                               Efl.Gfx.FilterNativeInherit.efl_gfx_filter_padding_get_ptr.Value.Delegate(this.NativeHandle, out l,  out r,  out t,  out b);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Bind an object to use as a mask or texture in a filter program.
   /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).
   /// 1.18</summary>
   /// <param name="name">Buffer name as used in the program.
   /// 1.18</param>
   /// <returns>Object to use as a source of pixels.
   /// 1.18</returns>
   public Efl.Gfx.Entity GetFilterSource(  System.String name) {
                         var _ret_var = Efl.Gfx.FilterNativeInherit.efl_gfx_filter_source_get_ptr.Value.Delegate(this.NativeHandle, name);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Bind an object to use as a mask or texture in a filter program.
   /// This will create automatically a new RGBA buffer containing the source object&apos;s pixels (as it is rendered).
   /// 1.18</summary>
   /// <param name="name">Buffer name as used in the program.
   /// 1.18</param>
   /// <param name="source">Object to use as a source of pixels.
   /// 1.18</param>
   /// <returns></returns>
   public  void SetFilterSource(  System.String name,  Efl.Gfx.Entity source) {
                                           Efl.Gfx.FilterNativeInherit.efl_gfx_filter_source_set_ptr.Value.Delegate(this.NativeHandle, name,  source);
      Eina.Error.RaiseIfUnhandledException();
                               }
   /// <summary>Extra data used by the filter program.
   /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
   /// 
   /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.
   /// 1.18</summary>
   /// <param name="name">Name of the global variable
   /// 1.18</param>
   /// <param name="value">String value to use as data
   /// 1.18</param>
   /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;
   /// 1.18</param>
   /// <returns></returns>
   public  void GetFilterData(  System.String name,  out  System.String value,  out bool execute) {
                                                             Efl.Gfx.FilterNativeInherit.efl_gfx_filter_data_get_ptr.Value.Delegate(this.NativeHandle, name,  out value,  out execute);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Extra data used by the filter program.
   /// Each data element is a string (<c>value</c>) stored as a global variable <c>name</c>. The program is then responsible for conversion to numbers, tables, etc...
   /// 
   /// If the <c>execute</c> flag is set, then the <c>value</c> can be complex and run, as if the original Lua program contained a line &apos;name = value&apos;. This can be used to pass in tables.
   /// 1.18</summary>
   /// <param name="name">Name of the global variable
   /// 1.18</param>
   /// <param name="value">String value to use as data
   /// 1.18</param>
   /// <param name="execute">If <c>true</c>, execute &apos;name = value&apos;
   /// 1.18</param>
   /// <returns></returns>
   public  void SetFilterData(  System.String name,   System.String value,  bool execute) {
                                                             Efl.Gfx.FilterNativeInherit.efl_gfx_filter_data_set_ptr.Value.Delegate(this.NativeHandle, name,  value,  execute);
      Eina.Error.RaiseIfUnhandledException();
                                           }
   /// <summary>Marks this filter as changed.</summary>
/// <value><c>true</c> if filter changed, <c>false</c> otherwise</value>
   public bool FilterChanged {
      set { SetFilterChanged( value); }
   }
   /// <summary>Marks this filter as invalid.</summary>
/// <value><c>true</c> if filter is invalid, <c>false</c> otherwise</value>
   public bool FilterInvalid {
      set { SetFilterInvalid( value); }
   }
   /// <summary>Retrieve cached output buffer, if any.
/// Does not increment the reference count.</summary>
/// <value>Output buffer</value>
   public  System.IntPtr FilterOutputBuffer {
      get { return GetFilterOutputBuffer(); }
   }
}
public class InternalNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Evas);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (evas_filter_changed_set_static_delegate == null)
      evas_filter_changed_set_static_delegate = new evas_filter_changed_set_delegate(filter_changed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_changed_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_changed_set_static_delegate)});
      if (evas_filter_invalid_set_static_delegate == null)
      evas_filter_invalid_set_static_delegate = new evas_filter_invalid_set_delegate(filter_invalid_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_invalid_set"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_invalid_set_static_delegate)});
      if (evas_filter_output_buffer_get_static_delegate == null)
      evas_filter_output_buffer_get_static_delegate = new evas_filter_output_buffer_get_delegate(filter_output_buffer_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_output_buffer_get"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_output_buffer_get_static_delegate)});
      if (evas_filter_input_alpha_static_delegate == null)
      evas_filter_input_alpha_static_delegate = new evas_filter_input_alpha_delegate(filter_input_alpha);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_input_alpha"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_alpha_static_delegate)});
      if (evas_filter_state_prepare_static_delegate == null)
      evas_filter_state_prepare_static_delegate = new evas_filter_state_prepare_delegate(filter_state_prepare);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_state_prepare"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_state_prepare_static_delegate)});
      if (evas_filter_input_render_static_delegate == null)
      evas_filter_input_render_static_delegate = new evas_filter_input_render_delegate(filter_input_render);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_input_render"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_input_render_static_delegate)});
      if (evas_filter_dirty_static_delegate == null)
      evas_filter_dirty_static_delegate = new evas_filter_dirty_delegate(filter_dirty);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "evas_filter_dirty"), func = Marshal.GetFunctionPointerForDelegate(evas_filter_dirty_static_delegate)});
      if (efl_gfx_filter_program_get_static_delegate == null)
      efl_gfx_filter_program_get_static_delegate = new efl_gfx_filter_program_get_delegate(filter_program_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_program_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_get_static_delegate)});
      if (efl_gfx_filter_program_set_static_delegate == null)
      efl_gfx_filter_program_set_static_delegate = new efl_gfx_filter_program_set_delegate(filter_program_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_program_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_program_set_static_delegate)});
      if (efl_gfx_filter_state_get_static_delegate == null)
      efl_gfx_filter_state_get_static_delegate = new efl_gfx_filter_state_get_delegate(filter_state_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_get_static_delegate)});
      if (efl_gfx_filter_state_set_static_delegate == null)
      efl_gfx_filter_state_set_static_delegate = new efl_gfx_filter_state_set_delegate(filter_state_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_state_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_state_set_static_delegate)});
      if (efl_gfx_filter_padding_get_static_delegate == null)
      efl_gfx_filter_padding_get_static_delegate = new efl_gfx_filter_padding_get_delegate(filter_padding_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_padding_get_static_delegate)});
      if (efl_gfx_filter_source_get_static_delegate == null)
      efl_gfx_filter_source_get_static_delegate = new efl_gfx_filter_source_get_delegate(filter_source_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_source_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_get_static_delegate)});
      if (efl_gfx_filter_source_set_static_delegate == null)
      efl_gfx_filter_source_set_static_delegate = new efl_gfx_filter_source_set_delegate(filter_source_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_source_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_source_set_static_delegate)});
      if (efl_gfx_filter_data_get_static_delegate == null)
      efl_gfx_filter_data_get_static_delegate = new efl_gfx_filter_data_get_delegate(filter_data_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_get_static_delegate)});
      if (efl_gfx_filter_data_set_static_delegate == null)
      efl_gfx_filter_data_set_static_delegate = new efl_gfx_filter_data_set_delegate(filter_data_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_filter_data_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_filter_data_set_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.Filter.InternalConcrete.efl_canvas_filter_internal_mixin_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.Filter.InternalConcrete.efl_canvas_filter_internal_mixin_get();
   }


    private delegate  void evas_filter_changed_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


    public delegate  void evas_filter_changed_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    public static Efl.Eo.FunctionWrapper<evas_filter_changed_set_api_delegate> evas_filter_changed_set_ptr = new Efl.Eo.FunctionWrapper<evas_filter_changed_set_api_delegate>(_Module, "evas_filter_changed_set");
    private static  void filter_changed_set(System.IntPtr obj, System.IntPtr pd,  bool val)
   {
      Eina.Log.Debug("function evas_filter_changed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((InternalConcrete)wrapper).SetFilterChanged( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         evas_filter_changed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private static evas_filter_changed_set_delegate evas_filter_changed_set_static_delegate;


    private delegate  void evas_filter_invalid_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool val);


    public delegate  void evas_filter_invalid_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool val);
    public static Efl.Eo.FunctionWrapper<evas_filter_invalid_set_api_delegate> evas_filter_invalid_set_ptr = new Efl.Eo.FunctionWrapper<evas_filter_invalid_set_api_delegate>(_Module, "evas_filter_invalid_set");
    private static  void filter_invalid_set(System.IntPtr obj, System.IntPtr pd,  bool val)
   {
      Eina.Log.Debug("function evas_filter_invalid_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((InternalConcrete)wrapper).SetFilterInvalid( val);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         evas_filter_invalid_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  val);
      }
   }
   private static evas_filter_invalid_set_delegate evas_filter_invalid_set_static_delegate;


    private delegate  System.IntPtr evas_filter_output_buffer_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  System.IntPtr evas_filter_output_buffer_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<evas_filter_output_buffer_get_api_delegate> evas_filter_output_buffer_get_ptr = new Efl.Eo.FunctionWrapper<evas_filter_output_buffer_get_api_delegate>(_Module, "evas_filter_output_buffer_get");
    private static  System.IntPtr filter_output_buffer_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function evas_filter_output_buffer_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.IntPtr _ret_var = default( System.IntPtr);
         try {
            _ret_var = ((InternalConcrete)wrapper).GetFilterOutputBuffer();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return evas_filter_output_buffer_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static evas_filter_output_buffer_get_delegate evas_filter_output_buffer_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool evas_filter_input_alpha_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool evas_filter_input_alpha_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<evas_filter_input_alpha_api_delegate> evas_filter_input_alpha_ptr = new Efl.Eo.FunctionWrapper<evas_filter_input_alpha_api_delegate>(_Module, "evas_filter_input_alpha");
    private static bool filter_input_alpha(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function evas_filter_input_alpha was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((InternalConcrete)wrapper).FilterInputAlpha();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return evas_filter_input_alpha_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static evas_filter_input_alpha_delegate evas_filter_input_alpha_static_delegate;


    private delegate  void evas_filter_state_prepare_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Canvas.Filter.State_StructInternal state,    System.IntPtr data);


    public delegate  void evas_filter_state_prepare_api_delegate(System.IntPtr obj,   out Efl.Canvas.Filter.State_StructInternal state,    System.IntPtr data);
    public static Efl.Eo.FunctionWrapper<evas_filter_state_prepare_api_delegate> evas_filter_state_prepare_ptr = new Efl.Eo.FunctionWrapper<evas_filter_state_prepare_api_delegate>(_Module, "evas_filter_state_prepare");
    private static  void filter_state_prepare(System.IntPtr obj, System.IntPtr pd,  out Efl.Canvas.Filter.State_StructInternal state,   System.IntPtr data)
   {
      Eina.Log.Debug("function evas_filter_state_prepare was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                           Efl.Canvas.Filter.State _out_state = default(Efl.Canvas.Filter.State);
                           
         try {
            ((InternalConcrete)wrapper).FilterStatePrepare( out _out_state,  data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      state = Efl.Canvas.Filter.State_StructConversion.ToInternal(_out_state);
                              } else {
         evas_filter_state_prepare_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out state,  data);
      }
   }
   private static evas_filter_state_prepare_delegate evas_filter_state_prepare_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool evas_filter_input_render_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr filter,    System.IntPtr engine,    System.IntPtr output,    System.IntPtr drawctx,    System.IntPtr data,    int l,    int r,    int t,    int b,    int x,    int y,  [MarshalAs(UnmanagedType.U1)]  bool do_async);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool evas_filter_input_render_api_delegate(System.IntPtr obj,    System.IntPtr filter,    System.IntPtr engine,    System.IntPtr output,    System.IntPtr drawctx,    System.IntPtr data,    int l,    int r,    int t,    int b,    int x,    int y,  [MarshalAs(UnmanagedType.U1)]  bool do_async);
    public static Efl.Eo.FunctionWrapper<evas_filter_input_render_api_delegate> evas_filter_input_render_ptr = new Efl.Eo.FunctionWrapper<evas_filter_input_render_api_delegate>(_Module, "evas_filter_input_render");
    private static bool filter_input_render(System.IntPtr obj, System.IntPtr pd,   System.IntPtr filter,   System.IntPtr engine,   System.IntPtr output,   System.IntPtr drawctx,   System.IntPtr data,   int l,   int r,   int t,   int b,   int x,   int y,  bool do_async)
   {
      Eina.Log.Debug("function evas_filter_input_render was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                                                                                                                                                          bool _ret_var = default(bool);
         try {
            _ret_var = ((InternalConcrete)wrapper).FilterInputRender( filter,  engine,  output,  drawctx,  data,  l,  r,  t,  b,  x,  y,  do_async);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                                                                                                      return _ret_var;
      } else {
         return evas_filter_input_render_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  filter,  engine,  output,  drawctx,  data,  l,  r,  t,  b,  x,  y,  do_async);
      }
   }
   private static evas_filter_input_render_delegate evas_filter_input_render_static_delegate;


    private delegate  void evas_filter_dirty_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void evas_filter_dirty_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<evas_filter_dirty_api_delegate> evas_filter_dirty_ptr = new Efl.Eo.FunctionWrapper<evas_filter_dirty_api_delegate>(_Module, "evas_filter_dirty");
    private static  void filter_dirty(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function evas_filter_dirty was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((InternalConcrete)wrapper).FilterDirty();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         evas_filter_dirty_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static evas_filter_dirty_delegate evas_filter_dirty_static_delegate;


    private delegate  void efl_gfx_filter_program_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String name);


    public delegate  void efl_gfx_filter_program_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String name);
    public static Efl.Eo.FunctionWrapper<efl_gfx_filter_program_get_api_delegate> efl_gfx_filter_program_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_program_get_api_delegate>(_Module, "efl_gfx_filter_program_get");
    private static  void filter_program_get(System.IntPtr obj, System.IntPtr pd,  out  System.String code,  out  System.String name)
   {
      Eina.Log.Debug("function efl_gfx_filter_program_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                            System.String _out_code = default( System.String);
       System.String _out_name = default( System.String);
                     
         try {
            ((InternalConcrete)wrapper).GetFilterProgram( out _out_code,  out _out_name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      code = _out_code;
      name = _out_name;
                        } else {
         efl_gfx_filter_program_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out code,  out name);
      }
   }
   private static efl_gfx_filter_program_get_delegate efl_gfx_filter_program_get_static_delegate;


    private delegate  void efl_gfx_filter_program_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);


    public delegate  void efl_gfx_filter_program_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String code,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    public static Efl.Eo.FunctionWrapper<efl_gfx_filter_program_set_api_delegate> efl_gfx_filter_program_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_program_set_api_delegate>(_Module, "efl_gfx_filter_program_set");
    private static  void filter_program_set(System.IntPtr obj, System.IntPtr pd,   System.String code,   System.String name)
   {
      Eina.Log.Debug("function efl_gfx_filter_program_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((InternalConcrete)wrapper).SetFilterProgram( code,  name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_filter_program_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  code,  name);
      }
   }
   private static efl_gfx_filter_program_set_delegate efl_gfx_filter_program_set_static_delegate;


    private delegate  void efl_gfx_filter_state_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String cur_state,   out double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String next_state,   out double next_val,   out double pos);


    public delegate  void efl_gfx_filter_state_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String cur_state,   out double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String next_state,   out double next_val,   out double pos);
    public static Efl.Eo.FunctionWrapper<efl_gfx_filter_state_get_api_delegate> efl_gfx_filter_state_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_state_get_api_delegate>(_Module, "efl_gfx_filter_state_get");
    private static  void filter_state_get(System.IntPtr obj, System.IntPtr pd,  out  System.String cur_state,  out double cur_val,  out  System.String next_state,  out double next_val,  out double pos)
   {
      Eina.Log.Debug("function efl_gfx_filter_state_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                              System.String _out_cur_state = default( System.String);
      cur_val = default(double);       System.String _out_next_state = default( System.String);
      next_val = default(double);      pos = default(double);                                       
         try {
            ((InternalConcrete)wrapper).GetFilterState( out _out_cur_state,  out cur_val,  out _out_next_state,  out next_val,  out pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      cur_state = _out_cur_state;
            next_state = _out_next_state;
                                                      } else {
         efl_gfx_filter_state_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out cur_state,  out cur_val,  out next_state,  out next_val,  out pos);
      }
   }
   private static efl_gfx_filter_state_get_delegate efl_gfx_filter_state_get_static_delegate;


    private delegate  void efl_gfx_filter_state_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cur_state,   double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String next_state,   double next_val,   double pos);


    public delegate  void efl_gfx_filter_state_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String cur_state,   double cur_val,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String next_state,   double next_val,   double pos);
    public static Efl.Eo.FunctionWrapper<efl_gfx_filter_state_set_api_delegate> efl_gfx_filter_state_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_state_set_api_delegate>(_Module, "efl_gfx_filter_state_set");
    private static  void filter_state_set(System.IntPtr obj, System.IntPtr pd,   System.String cur_state,  double cur_val,   System.String next_state,  double next_val,  double pos)
   {
      Eina.Log.Debug("function efl_gfx_filter_state_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                                            
         try {
            ((InternalConcrete)wrapper).SetFilterState( cur_state,  cur_val,  next_state,  next_val,  pos);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                                        } else {
         efl_gfx_filter_state_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cur_state,  cur_val,  next_state,  next_val,  pos);
      }
   }
   private static efl_gfx_filter_state_set_delegate efl_gfx_filter_state_set_static_delegate;


    private delegate  void efl_gfx_filter_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int l,   out  int r,   out  int t,   out  int b);


    public delegate  void efl_gfx_filter_padding_get_api_delegate(System.IntPtr obj,   out  int l,   out  int r,   out  int t,   out  int b);
    public static Efl.Eo.FunctionWrapper<efl_gfx_filter_padding_get_api_delegate> efl_gfx_filter_padding_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_padding_get_api_delegate>(_Module, "efl_gfx_filter_padding_get");
    private static  void filter_padding_get(System.IntPtr obj, System.IntPtr pd,  out  int l,  out  int r,  out  int t,  out  int b)
   {
      Eina.Log.Debug("function efl_gfx_filter_padding_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       l = default( int);      r = default( int);      t = default( int);      b = default( int);                                 
         try {
            ((InternalConcrete)wrapper).GetFilterPadding( out l,  out r,  out t,  out b);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_filter_padding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out l,  out r,  out t,  out b);
      }
   }
   private static efl_gfx_filter_padding_get_delegate efl_gfx_filter_padding_get_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_gfx_filter_source_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_gfx_filter_source_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name);
    public static Efl.Eo.FunctionWrapper<efl_gfx_filter_source_get_api_delegate> efl_gfx_filter_source_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_source_get_api_delegate>(_Module, "efl_gfx_filter_source_get");
    private static Efl.Gfx.Entity filter_source_get(System.IntPtr obj, System.IntPtr pd,   System.String name)
   {
      Eina.Log.Debug("function efl_gfx_filter_source_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((InternalConcrete)wrapper).GetFilterSource( name);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_gfx_filter_source_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name);
      }
   }
   private static efl_gfx_filter_source_get_delegate efl_gfx_filter_source_get_static_delegate;


    private delegate  void efl_gfx_filter_source_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity source);


    public delegate  void efl_gfx_filter_source_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity source);
    public static Efl.Eo.FunctionWrapper<efl_gfx_filter_source_set_api_delegate> efl_gfx_filter_source_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_source_set_api_delegate>(_Module, "efl_gfx_filter_source_set");
    private static  void filter_source_set(System.IntPtr obj, System.IntPtr pd,   System.String name,  Efl.Gfx.Entity source)
   {
      Eina.Log.Debug("function efl_gfx_filter_source_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      
         try {
            ((InternalConcrete)wrapper).SetFilterSource( name,  source);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                    } else {
         efl_gfx_filter_source_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  source);
      }
   }
   private static efl_gfx_filter_source_set_delegate efl_gfx_filter_source_set_static_delegate;


    private delegate  void efl_gfx_filter_data_get_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String value,  [MarshalAs(UnmanagedType.U1)]  out bool execute);


    public delegate  void efl_gfx_filter_data_get_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  out  System.String value,  [MarshalAs(UnmanagedType.U1)]  out bool execute);
    public static Efl.Eo.FunctionWrapper<efl_gfx_filter_data_get_api_delegate> efl_gfx_filter_data_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_data_get_api_delegate>(_Module, "efl_gfx_filter_data_get");
    private static  void filter_data_get(System.IntPtr obj, System.IntPtr pd,   System.String name,  out  System.String value,  out bool execute)
   {
      Eina.Log.Debug("function efl_gfx_filter_data_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                        System.String _out_value = default( System.String);
      execute = default(bool);                           
         try {
            ((InternalConcrete)wrapper).GetFilterData( name,  out _out_value,  out execute);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            value = _out_value;
                                    } else {
         efl_gfx_filter_data_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  out value,  out execute);
      }
   }
   private static efl_gfx_filter_data_get_delegate efl_gfx_filter_data_get_static_delegate;


    private delegate  void efl_gfx_filter_data_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value,  [MarshalAs(UnmanagedType.U1)]  bool execute);


    public delegate  void efl_gfx_filter_data_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String value,  [MarshalAs(UnmanagedType.U1)]  bool execute);
    public static Efl.Eo.FunctionWrapper<efl_gfx_filter_data_set_api_delegate> efl_gfx_filter_data_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_filter_data_set_api_delegate>(_Module, "efl_gfx_filter_data_set");
    private static  void filter_data_set(System.IntPtr obj, System.IntPtr pd,   System.String name,   System.String value,  bool execute)
   {
      Eina.Log.Debug("function efl_gfx_filter_data_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        
         try {
            ((InternalConcrete)wrapper).SetFilterData( name,  value,  execute);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                } else {
         efl_gfx_filter_data_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  value,  execute);
      }
   }
   private static efl_gfx_filter_data_set_delegate efl_gfx_filter_data_set_static_delegate;
}
} } } 
namespace Efl { namespace Gfx { 
/// <summary>32 bit color data structure</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Color32
{
   /// <summary>Red component of the color</summary>
   public  byte R;
   /// <summary>Green component of the color</summary>
   public  byte G;
   /// <summary>Blue component of the color</summary>
   public  byte B;
   /// <summary>Translucent component of the color</summary>
   public  byte A;
   ///<summary>Constructor for Color32.</summary>
   public Color32(
       byte R=default( byte),
       byte G=default( byte),
       byte B=default( byte),
       byte A=default( byte)   )
   {
      this.R = R;
      this.G = G;
      this.B = B;
      this.A = A;
   }
public static implicit operator Color32(IntPtr ptr)
   {
      var tmp = (Color32_StructInternal)Marshal.PtrToStructure(ptr, typeof(Color32_StructInternal));
      return Color32_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct Color32.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct Color32_StructInternal
{
   
   public  byte R;
   
   public  byte G;
   
   public  byte B;
   
   public  byte A;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator Color32(Color32_StructInternal struct_)
   {
      return Color32_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator Color32_StructInternal(Color32 struct_)
   {
      return Color32_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct Color32</summary>
public static class Color32_StructConversion
{
   internal static Color32_StructInternal ToInternal(Color32 _external_struct)
   {
      var _internal_struct = new Color32_StructInternal();

      _internal_struct.R = _external_struct.R;
      _internal_struct.G = _external_struct.G;
      _internal_struct.B = _external_struct.B;
      _internal_struct.A = _external_struct.A;

      return _internal_struct;
   }

   internal static Color32 ToManaged(Color32_StructInternal _internal_struct)
   {
      var _external_struct = new Color32();

      _external_struct.R = _internal_struct.R;
      _external_struct.G = _internal_struct.G;
      _external_struct.B = _internal_struct.B;
      _external_struct.A = _internal_struct.A;

      return _external_struct;
   }

}
} } 
namespace Efl { namespace Canvas { namespace Filter { 
/// <summary>Filter state name structure</summary>
[StructLayout(LayoutKind.Sequential)]
public struct StateName
{
   /// <summary>Filter state name</summary>
   public  System.String Name;
   /// <summary>Filter state value</summary>
   public double Value;
   ///<summary>Constructor for StateName.</summary>
   public StateName(
       System.String Name=default( System.String),
      double Value=default(double)   )
   {
      this.Name = Name;
      this.Value = Value;
   }
public static implicit operator StateName(IntPtr ptr)
   {
      var tmp = (StateName_StructInternal)Marshal.PtrToStructure(ptr, typeof(StateName_StructInternal));
      return StateName_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct StateName.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct StateName_StructInternal
{
///<summary>Internal wrapper for field Name</summary>
public System.IntPtr Name;
   
   public double Value;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator StateName(StateName_StructInternal struct_)
   {
      return StateName_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator StateName_StructInternal(StateName struct_)
   {
      return StateName_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct StateName</summary>
public static class StateName_StructConversion
{
   internal static StateName_StructInternal ToInternal(StateName _external_struct)
   {
      var _internal_struct = new StateName_StructInternal();

      _internal_struct.Name = Eina.MemoryNative.StrDup(_external_struct.Name);
      _internal_struct.Value = _external_struct.Value;

      return _internal_struct;
   }

   internal static StateName ToManaged(StateName_StructInternal _internal_struct)
   {
      var _external_struct = new StateName();

      _external_struct.Name = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Name);
      _external_struct.Value = _internal_struct.Value;

      return _external_struct;
   }

}
} } } 
namespace Efl { namespace Canvas { namespace Filter { 
/// <summary>Filter state text structure</summary>
[StructLayout(LayoutKind.Sequential)]
public struct StateText
{
   /// <summary>Text outline color</summary>
   public Efl.Gfx.Color32 Outline;
   /// <summary>Text shadow color</summary>
   public Efl.Gfx.Color32 Shadow;
   /// <summary>Text glow color</summary>
   public Efl.Gfx.Color32 Glow;
   /// <summary>Text glow2 color</summary>
   public Efl.Gfx.Color32 Glow2;
   ///<summary>Constructor for StateText.</summary>
   public StateText(
      Efl.Gfx.Color32 Outline=default(Efl.Gfx.Color32),
      Efl.Gfx.Color32 Shadow=default(Efl.Gfx.Color32),
      Efl.Gfx.Color32 Glow=default(Efl.Gfx.Color32),
      Efl.Gfx.Color32 Glow2=default(Efl.Gfx.Color32)   )
   {
      this.Outline = Outline;
      this.Shadow = Shadow;
      this.Glow = Glow;
      this.Glow2 = Glow2;
   }
public static implicit operator StateText(IntPtr ptr)
   {
      var tmp = (StateText_StructInternal)Marshal.PtrToStructure(ptr, typeof(StateText_StructInternal));
      return StateText_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct StateText.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct StateText_StructInternal
{
   
   public Efl.Gfx.Color32_StructInternal Outline;
   
   public Efl.Gfx.Color32_StructInternal Shadow;
   
   public Efl.Gfx.Color32_StructInternal Glow;
   
   public Efl.Gfx.Color32_StructInternal Glow2;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator StateText(StateText_StructInternal struct_)
   {
      return StateText_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator StateText_StructInternal(StateText struct_)
   {
      return StateText_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct StateText</summary>
public static class StateText_StructConversion
{
   internal static StateText_StructInternal ToInternal(StateText _external_struct)
   {
      var _internal_struct = new StateText_StructInternal();

      _internal_struct.Outline = Efl.Gfx.Color32_StructConversion.ToInternal(_external_struct.Outline);
      _internal_struct.Shadow = Efl.Gfx.Color32_StructConversion.ToInternal(_external_struct.Shadow);
      _internal_struct.Glow = Efl.Gfx.Color32_StructConversion.ToInternal(_external_struct.Glow);
      _internal_struct.Glow2 = Efl.Gfx.Color32_StructConversion.ToInternal(_external_struct.Glow2);

      return _internal_struct;
   }

   internal static StateText ToManaged(StateText_StructInternal _internal_struct)
   {
      var _external_struct = new StateText();

      _external_struct.Outline = Efl.Gfx.Color32_StructConversion.ToManaged(_internal_struct.Outline);
      _external_struct.Shadow = Efl.Gfx.Color32_StructConversion.ToManaged(_internal_struct.Shadow);
      _external_struct.Glow = Efl.Gfx.Color32_StructConversion.ToManaged(_internal_struct.Glow);
      _external_struct.Glow2 = Efl.Gfx.Color32_StructConversion.ToManaged(_internal_struct.Glow2);

      return _external_struct;
   }

}
} } } 
namespace Efl { namespace Canvas { namespace Filter { 
/// <summary>Internal structure representing the state of a Gfx Filter</summary>
[StructLayout(LayoutKind.Sequential)]
public struct State
{
   /// <summary>Text state</summary>
   public Efl.Canvas.Filter.StateText Text;
   /// <summary>Color</summary>
   public Efl.Gfx.Color32 Color;
   /// <summary>Current state</summary>
   public Efl.Canvas.Filter.StateName Cur;
   /// <summary>Next state</summary>
   public Efl.Canvas.Filter.StateName Next;
   /// <summary>Width</summary>
   public  int W;
   /// <summary>Height</summary>
   public  int H;
   /// <summary>Scale factor</summary>
   public double Scale;
   /// <summary>Position</summary>
   public double Pos;
   ///<summary>Constructor for State.</summary>
   public State(
      Efl.Canvas.Filter.StateText Text=default(Efl.Canvas.Filter.StateText),
      Efl.Gfx.Color32 Color=default(Efl.Gfx.Color32),
      Efl.Canvas.Filter.StateName Cur=default(Efl.Canvas.Filter.StateName),
      Efl.Canvas.Filter.StateName Next=default(Efl.Canvas.Filter.StateName),
       int W=default( int),
       int H=default( int),
      double Scale=default(double),
      double Pos=default(double)   )
   {
      this.Text = Text;
      this.Color = Color;
      this.Cur = Cur;
      this.Next = Next;
      this.W = W;
      this.H = H;
      this.Scale = Scale;
      this.Pos = Pos;
   }
public static implicit operator State(IntPtr ptr)
   {
      var tmp = (State_StructInternal)Marshal.PtrToStructure(ptr, typeof(State_StructInternal));
      return State_StructConversion.ToManaged(tmp);
   }
}
///<summary>Internal wrapper for struct State.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct State_StructInternal
{
   
   public Efl.Canvas.Filter.StateText_StructInternal Text;
   
   public Efl.Gfx.Color32_StructInternal Color;
   
   public Efl.Canvas.Filter.StateName_StructInternal Cur;
   
   public Efl.Canvas.Filter.StateName_StructInternal Next;
   
   public  int W;
   
   public  int H;
   
   public double Scale;
   
   public double Pos;
   ///<summary>Implicit conversion to the internal/marshalling representation.</summary>
   public static implicit operator State(State_StructInternal struct_)
   {
      return State_StructConversion.ToManaged(struct_);
   }
   ///<summary>Implicit conversion to the managed representation.</summary>
   public static implicit operator State_StructInternal(State struct_)
   {
      return State_StructConversion.ToInternal(struct_);
   }
}
/// <summary>Conversion class for struct State</summary>
public static class State_StructConversion
{
   internal static State_StructInternal ToInternal(State _external_struct)
   {
      var _internal_struct = new State_StructInternal();

      _internal_struct.Text = Efl.Canvas.Filter.StateText_StructConversion.ToInternal(_external_struct.Text);
      _internal_struct.Color = Efl.Gfx.Color32_StructConversion.ToInternal(_external_struct.Color);
      _internal_struct.Cur = Efl.Canvas.Filter.StateName_StructConversion.ToInternal(_external_struct.Cur);
      _internal_struct.Next = Efl.Canvas.Filter.StateName_StructConversion.ToInternal(_external_struct.Next);
      _internal_struct.W = _external_struct.W;
      _internal_struct.H = _external_struct.H;
      _internal_struct.Scale = _external_struct.Scale;
      _internal_struct.Pos = _external_struct.Pos;

      return _internal_struct;
   }

   internal static State ToManaged(State_StructInternal _internal_struct)
   {
      var _external_struct = new State();

      _external_struct.Text = Efl.Canvas.Filter.StateText_StructConversion.ToManaged(_internal_struct.Text);
      _external_struct.Color = Efl.Gfx.Color32_StructConversion.ToManaged(_internal_struct.Color);
      _external_struct.Cur = Efl.Canvas.Filter.StateName_StructConversion.ToManaged(_internal_struct.Cur);
      _external_struct.Next = Efl.Canvas.Filter.StateName_StructConversion.ToManaged(_internal_struct.Next);
      _external_struct.W = _internal_struct.W;
      _external_struct.H = _internal_struct.H;
      _external_struct.Scale = _internal_struct.Scale;
      _external_struct.Pos = _internal_struct.Pos;

      return _external_struct;
   }

}
} } } 

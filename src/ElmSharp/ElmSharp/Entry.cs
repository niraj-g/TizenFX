/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ElmSharp
{
    /// <summary>
    /// Enumeration for describing InputPanel layout type.
    /// </summary>
    public enum InputPanelLayout
    {
        /// <summary>
        /// InputPanel layout type default.
        /// </summary>
        Normal,

        /// <summary>
        /// InputPanel layout type number.
        /// </summary>
        Number,

        /// <summary>
        /// InputPanel layout type email.
        /// </summary>
        Email,

        /// <summary>
        /// InputPanel layout type url.
        /// </summary>
        Url,

        /// <summary>
        /// InputPanel layout type phone.
        /// </summary>
        PhoneNumber,

        /// <summary>
        /// InputPanel layout type ip.
        /// </summary>
        Ip,

        /// <summary>
        /// InputPanel layout type month.
        /// </summary>
        Month,

        /// <summary>
        /// InputPanel layout type number.
        /// </summary>
        NumberOnly,

        /// <summary>
        /// InputPanel layout type error type. Do not use it directly!
        /// </summary>
        Invalid,

        /// <summary>
        /// InputPanel layout type hexadecimal.
        /// </summary>
        Hex,

        /// <summary>
        /// InputPanel layout type terminal type, esc, alt, ctrl, etc.
        /// </summary>
        Terminal,

        /// <summary>
        /// InputPanel layout type password.
        /// </summary>
        Password,

        /// <summary>
        /// Keyboard layout type date and time.
        /// </summary>
        DateTime,

        /// <summary>
        /// InputPanel layout type emoticons.
        /// </summary>
        Emoticon
    }

    /// <summary>
    /// Enumeration that defines the "Return" key types on the input panel (virtual keyboard).
    /// </summary>
    public enum InputPanelReturnKeyType
    {
        /// <summary>
        /// Default key type
        /// </summary>
        Default,

        /// <summary>
        /// Done key type
        /// </summary>
        Done,

        /// <summary>
        /// Go key type
        /// </summary>
        Go,

        /// <summary>
        /// Join key type
        /// </summary>
        Join,

        /// <summary>
        /// Login key type
        /// </summary>
        Login,

        /// <summary>
        /// Next key type
        /// </summary>
        Next,

        /// <summary>
        /// Search string or magnifier icon key type
        /// </summary>
        Search,

        /// <summary>
        /// Send key type
        /// </summary>
        Send,

        /// <summary>
        /// Sign-in key type
        /// </summary>
        Signin
    }

    /// <summary>
    /// Enumeration that defines the autocapitalization types.
    /// </summary>
    public enum AutoCapital
    {
        /// <summary>
        /// No autocapitalization when typing
        /// </summary>
        None,

        /// <summary>
        /// Autocapitalize each typed word
        /// </summary>
        Word,

        /// <summary>
        /// Autocapitalize the start of each sentence
        /// </summary>
        Sentence,

        /// <summary>
        /// Autocapitalize all letters
        /// </summary>
        All
    }

    /// <summary>
    /// Enumeration that defines the entry's copy and paste policy.
    /// </summary>
    public enum CopyAndPasteMode
    {
        /// <summary>
        /// Copy and paste text with markup tag
        /// </summary>
        Markup,

        /// <summary>
        /// Copy and paste text without item(image) tag
        /// </summary>
        NoImage,

        /// <summary>
        /// Copy and paste text without markup tag
        /// </summary>
        PlainText
    }

    /// <summary>
    /// Enumeration that defines the text format types.
    /// </summary>
    public enum TextFormat
    {
        /// <summary>
        /// Plain type
        /// </summary>
        Plain,

        /// <summary>
        /// Markup type
        /// </summary>
        Markup
    }

    /// <summary>
    /// Enumeration that defines the types of Input Hints.
    /// </summary>
    public enum InputHints
    {
        /// <summary>
        /// No active hints
        /// </summary>
        None,

        /// <summary>
        /// suggest word auto completion
        /// </summary>
        AutoComplete,

        /// <summary>
        /// typed text should not be stored.
        /// </summary>
        SensitiveData,
    }

    /// <summary>
    /// Enumeration that defines the input panel (virtual keyboard) language modes.
    /// </summary>
    public enum InputPanelLanguage
    {
        /// <summary>
        /// Automatic language mode
        /// </summary>
        Automatic,

        /// <summary>
        /// Alphabet language mode
        /// </summary>
        Alphabet,
    }

    /// <summary>
    /// The entry is a convenience widget that shows a box in which the user can enter text.
    /// </summary>
    public class Entry : Layout, IScrollable
    {
        ScrollableAdapter _scroller;
        SmartEvent _clicked;
        SmartEvent _changedByUser;
        SmartEvent _cursorChanged;
        SmartEvent _activated;

        Dictionary<Func<string, EvasObject>, Interop.Elementary.Elm_Entry_Item_Provider_Cb> _itemsProvider = new Dictionary<Func<string, EvasObject>, Interop.Elementary.Elm_Entry_Item_Provider_Cb>();
        Dictionary<Func<Entry, string, string>, Interop.Elementary.Elm_Entry_Filter_Cb> _textFilters = new Dictionary<Func<Entry, string, string>, Interop.Elementary.Elm_Entry_Filter_Cb>();

        /// <summary>
        /// Creates and initializes a new instance of the Entry class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new Entry will be attached as a child.</param>
        public Entry(EvasObject parent) : base(parent)
        {
            _clicked = new SmartEvent(this, this.RealHandle, "clicked");
            _clicked.On += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);

            _changedByUser = new SmartEvent(this, this.RealHandle, "changed,user");
            _changedByUser.On += (s, e) => ChangedByUser?.Invoke(this, EventArgs.Empty);

            _cursorChanged = new SmartEvent(this, this.RealHandle, "cursor,changed");
            _cursorChanged.On += (s, e) => CursorChanged?.Invoke(this, EventArgs.Empty);

            _activated = new SmartEvent(this, this.RealHandle, "activated");
            _activated.On += (s, e) => Activated?.Invoke(this, EventArgs.Empty);

            _scroller = new ScrollableAdapter(this);
        }

        /// <summary>
        /// Activated will be triggered when the entry in Activated stated.
        /// </summary>
        public event EventHandler Activated;

        /// <summary>
        /// Clicked will be triggered when the entry is clicked.
        /// </summary>
        public event EventHandler Clicked;

        /// <summary>
        /// ChangedByUser will be triggered when the entry changed by user.
        /// </summary>
        public event EventHandler ChangedByUser;

        /// <summary>
        /// CursorChanged will be triggered when the Cursor in the entry is changed.
        /// </summary>
        public event EventHandler CursorChanged;

        /// <summary>
        /// Sets or gets the entry to the single line mode.
        /// </summary>
        public bool IsSingleLine
        {
            get
            {
                return Interop.Elementary.elm_entry_single_line_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_single_line_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the entry to the password mode.
        /// </summary>
        public bool IsPassword
        {
            get
            {
                return Interop.Elementary.elm_entry_password_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_password_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the entry is editable.
        /// </summary>
        public bool IsEditable
        {
            get
            {
                return Interop.Elementary.elm_entry_editable_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_editable_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the entry is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Interop.Elementary.elm_entry_is_empty(RealHandle);
            }
        }

        /// <summary>
        /// Sets or gets text currently shown in the object entry.
        /// </summary>
        public override string Text
        {
            get
            {
                return Interop.Elementary.elm_entry_entry_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_entry_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the style on the top of the user style stack.
        /// </summary>
        /// <remarks>If there is styles in the user style stack, the properties in the top style of user style stack will replace the properties in current theme. The input style is specified in format tag='property=value' (i.e. DEFAULT='font=Sans font_size=60'hilight=' + font_weight=Bold').</remarks>
        public string TextStyle
        {
            get
            {
                return Interop.Elementary.elm_entry_text_style_user_peek(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_text_style_user_push(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the current position of the cursor in the entry.
        /// </summary>
        public int CursorPosition
        {
            get
            {
                return Interop.Elementary.elm_entry_cursor_pos_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_cursor_pos_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the scrollable state of the entry.
        /// </summary>
        public bool Scrollable
        {
            get
            {
                return Interop.Elementary.elm_entry_scrollable_get(RealHandle);
            }
            set
            {
                // HACK: Enabling the scrollable property of an entry causes its internal
                //       hierarchy to change, making the internal edje object inaccessible.
                //       Access it before the property is set, to cache the edje object's handle.
                if (value)
                {
                    var dummy = EdjeObject;
                }
                Interop.Elementary.elm_entry_scrollable_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or Gets the autocapitalization type on the immodule.
        /// </summary>
        public AutoCapital AutoCapital
        {
            get
            {
                return (AutoCapital)Interop.Elementary.elm_entry_autocapital_type_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_autocapital_type_set(RealHandle, (Interop.Elementary.AutocapitalType)value);
            }
        }

        /// <summary>
        /// Sets or Gets the entry object's 'autosave' status.
        /// </summary>
        public bool IsAutoSave
        {
            get
            {
                return Interop.Elementary.elm_entry_autosave_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_autosave_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or Gets entry text paste/drop mode.
        /// </summary>
        public CopyAndPasteMode CopyAndPasteMode
        {
            get
            {
                return (CopyAndPasteMode)Interop.Elementary.elm_entry_cnp_mode_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_cnp_mode_set(RealHandle, (Interop.Elementary.CopyAndPasteMode)value);
            }
        }

        /// <summary>
        /// Gets the geometry of the cursor.
        /// </summary>
        public Rect CursorGeometry
        {
            get
            {
                int x, y, w, h;
                Interop.Elementary.elm_entry_cursor_geometry_get(RealHandle, out x, out y, out w, out h);
                return new Rect(x, y, w, h);
            }
        }

        /// <summary>
        /// Gets whether a format node exists at the current cursor position.
        /// </summary>
        public bool IsCursorFormat
        {
            get
            {
                return Interop.Elementary.elm_entry_cursor_is_format_get(RealHandle);
            }
        }

        /// <summary>
        /// Gets if the current cursor position holds a visible format node.
        /// </summary>
        public bool IsCursorVisibelFormat
        {
            get
            {
                return Interop.Elementary.elm_entry_cursor_is_visible_format_get(RealHandle);
            }
        }

        /// <summary>
        /// Sets or Gets the value of input hint.
        /// </summary>
        public InputHints InputHint
        {
            get
            {
                return (InputHints)Interop.Elementary.elm_entry_input_hint_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_input_hint_set(RealHandle, (Interop.Elementary.InputHints)value);
            }
        }

        /// <summary>
        ///  Sets or gets the language mode of the input panel.
        /// </summary>
        public InputPanelLanguage InputPanelLanguage
        {
            get
            {
                return (InputPanelLanguage)Interop.Elementary.elm_entry_input_panel_language_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_input_panel_language_set(RealHandle, (Interop.Elementary.InputPanelLanguage)value);
            }
        }

        /// <summary>
        /// Sets or gets the input panel layout variation of the entry.
        /// </summary>
        public int InputPanelVariation
        {
            get
            {
                return Interop.Elementary.elm_entry_input_panel_layout_variation_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_input_panel_layout_variation_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the line wrap type to use on multi-line entries.
        /// </summary>
        public WrapType LineWrapType
        {
            get
            {
                return (WrapType)Interop.Elementary.elm_entry_line_wrap_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_line_wrap_set(RealHandle, (Interop.Elementary.WrapType)value);
            }
        }

        /// <summary>
        /// Sets or gets whether the entry should allow to use the text prediction.
        /// </summary>
        public bool PredictionAllowed
        {
            get
            {
                return Interop.Elementary.elm_entry_prediction_allow_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_prediction_allow_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether the return key on the input panel should be disabled or not.
        /// </summary>
        public bool InputPanelReturnKeyDisabled
        {
            get
            {
                return Interop.Elementary.elm_entry_input_panel_return_key_disabled_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_input_panel_return_key_disabled_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets or gets the attribute to show the input panel in case of only an user's explicit Mouse Up event.
        /// It doesn't request to show the input panel even though it has focus.
        /// If true, the input panel will be shown in case of only Mouse up event. (Focus event will be ignored.)
        /// </summary>
        public bool InputPanelShowByOnDemand
        {
            get
            {
                return Interop.Elementary.elm_entry_input_panel_show_on_demand_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_entry_input_panel_show_on_demand_set(RealHandle, value);
            }
        }

        /// <summary>
        /// Sets the file (and implicitly loads it) for the text to display and then edit.
        /// </summary>
        /// <param name="file">The path to the file to load and save</param>
        /// <param name="textFormat">The file format</param>
        public void SetFile(string file, TextFormat textFormat)
        {
            Interop.Elementary.elm_entry_file_set(RealHandle, file, (Interop.Elementary.TextFormat)textFormat);
        }

        /// <summary>
        /// Converts a markup (HTML-like) string into UTF-8.
        /// </summary>
        /// <param name="markup">The string (in markup) to be converted</param>
        /// <returns>The converted string (in UTF-8) </returns>
        public static string ConvertMarkupToUtf8(string markup)
        {
            return Interop.Elementary.elm_entry_markup_to_utf8(markup);
        }

        /// <summary>
        /// Moves the cursor by one position to the right within the entry.
        /// </summary>
        /// <returns></returns>
        public bool MoveCursorNext()
        {
            return Interop.Elementary.elm_entry_cursor_next(RealHandle);
        }

        /// <summary>
        /// Moves the cursor one place to the left within the entry.
        /// </summary>
        /// <returns>TRUE on success, otherwise FALSE on failure</returns>
        public bool MoveCursorPrev()
        {
            return Interop.Elementary.elm_entry_cursor_prev(RealHandle);
        }

        /// <summary>
        /// Moves the cursor one line up within the entry.
        /// </summary>
        /// <returns>TRUE on success, otherwise FALSE on failure</returns>
        public bool MoveCursorUp()
        {
            return Interop.Elementary.elm_entry_cursor_up(RealHandle);
        }

        /// <summary>
        /// Moves the cursor one line down within the entry.
        /// </summary>
        /// <returns>TRUE on success, otherwise FALSE on failure</returns>
        public bool MoveCursorDown()
        {
            return Interop.Elementary.elm_entry_cursor_down(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the beginning of the entry.
        /// </summary>
        public void MoveCursorBegin()
        {
            Interop.Elementary.elm_entry_cursor_begin_set(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the end of the entry.
        /// </summary>
        public void MoveCursorEnd()
        {
            Interop.Elementary.elm_entry_cursor_end_set(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the beginning of the current line.
        /// </summary>
        public void MoveCursorLineBegin()
        {
            Interop.Elementary.elm_entry_cursor_line_begin_set(RealHandle);
        }

        /// <summary>
        /// Moves the cursor to the end of the current line.
        /// </summary>
        public void MoveCursorLineEnd()
        {
            Interop.Elementary.elm_entry_cursor_line_end_set(RealHandle);
        }

        /// <summary>
        /// Sets the input panel layout of the entry.
        /// </summary>
        /// <param name="layout">The layout type</param>
        public void SetInputPanelLayout(InputPanelLayout layout)
        {
            Interop.Elementary.elm_entry_input_panel_layout_set(RealHandle, (Interop.Elementary.InputPanelLayout)layout);
        }

        /// <summary>
        /// Sets the attribute to show the input panel automatically.
        /// </summary>
        /// <param name="enabled">If true the input panel appears when the entry is clicked or has focus, otherwise false</param>
        public void SetInputPanelEnabled(bool enabled)
        {
            Interop.Elementary.elm_entry_input_panel_enabled_set(RealHandle, enabled);
        }

        /// <summary>
        /// Sets the "return" key type. This type is used to set the string or icon on the "return" key of the input panel.
        /// </summary>
        /// <param name="keyType">The type of "return" key on the input panel</param>
        public void SetInputPanelReturnKeyType(InputPanelReturnKeyType keyType)
        {
            Interop.Elementary.elm_entry_input_panel_return_key_type_set(RealHandle, (Interop.Elementary.ReturnKeyType)keyType);
        }

        /// <summary>
        /// Hides the input panel (virtual keyboard).
        /// </summary>
        /// <remarks>
        /// Note that the input panel is shown or hidden automatically according to the focus state of the entry widget.
        /// This API can be used in case of manually controlling by using SetInputPanelEnabled(false).
        /// </remarks>
        public void HideInputPanel()
        {
            Interop.Elementary.elm_entry_input_panel_hide(RealHandle);
        }

        /// <summary>
        /// Selects all the text within the entry.
        /// </summary>
        public void SelectAll()
        {
            Interop.Elementary.elm_entry_select_all(RealHandle);
        }

        /// <summary>
        /// Drops any existing text selection within the entry.
        /// </summary>
        public void SelectNone()
        {
            Interop.Elementary.elm_entry_select_none(RealHandle);
        }

        /// <summary>
        /// Forces calculation of the entry size and text layouting.
        /// </summary>
        public void ForceCalculation()
        {
            Interop.Elementary.elm_entry_calc_force(RealHandle);
        }

        /// <summary>
        /// Gets the string by the cursor at its current position.
        /// </summary>
        /// <returns></returns>
        public string GetCursorContent()
        {
            return Interop.Elementary.elm_entry_cursor_content_get(RealHandle);
        }

        /// <summary>
        /// Begins a selection within the entry as though the user were holding down the mouse button to make a selection.
        /// </summary>
        public void BeginCursorSelection()
        {
            Interop.Elementary.elm_entry_cursor_selection_begin(RealHandle);
        }

        /// <summary>
        /// Appends the text of the entry.
        /// </summary>
        /// <param name="text">The text to be displayed</param>
        public void AppendText(string text)
        {
            Interop.Elementary.elm_entry_entry_append(RealHandle, text);
        }

        /// <summary>
        /// Inserts the given text into the entry at the current cursor position.
        /// </summary>
        /// <param name="text"></param>
        public void InsertTextToCursor(string text)
        {
            Interop.Elementary.elm_entry_entry_insert(RealHandle, text);
        }

        /// <summary>
        /// Ends a selection within the entry as though the user had just released the mouse button while making a selection.
        /// </summary>
        public void EndCursorSelection()
        {
            Interop.Elementary.elm_entry_cursor_selection_end(RealHandle);
        }

        /// <summary>
        /// Writes any changes made to the file that is set by File.
        /// </summary>
        public void SaveFile()
        {
            Interop.Elementary.elm_entry_file_save(RealHandle);
        }

        /// <summary>
        /// Show the input panel (virtual keyboard) based on the input panel property of entry such as layout, autocapital types, and so on.
        /// </summary>
        /// <remarks>
        /// Note that input panel is shown or hidden automatically according to the focus state of entry widget.
        /// This API can be used in the case of manually controlling by using SetInputPanelEnabled(false).
        /// </remarks>
        public void ShowInputPanel()
        {
            Interop.Elementary.elm_entry_input_panel_show(RealHandle);
        }

        /// <summary>
        /// This appends a custom item provider to the list for that entry.
        /// </summary>
        /// <param name="func">This function is used to provide items.</param>
        public void AppendItemProvider(Func<string, EvasObject> func)
        {
            if (func != null)
            {
                if (!_itemsProvider.ContainsKey(func))
                {
                    Interop.Elementary.Elm_Entry_Item_Provider_Cb itemProviderCallback;

                    itemProviderCallback = (d, o, t) =>
                    {
                        return func?.Invoke(t);
                    };
                    Interop.Elementary.elm_entry_item_provider_append(RealHandle, itemProviderCallback, IntPtr.Zero);
                    _itemsProvider.Add(func, itemProviderCallback);
                }
            }
        }

        /// <summary>
        /// This prepends a custom item provider to the list for that entry.
        /// </summary>
        /// <param name="func">This function is used to provide items.</param>
        public void PrependItemProvider(Func<string, EvasObject> func)
        {
            if (!_itemsProvider.ContainsKey(func))
            {
                Interop.Elementary.Elm_Entry_Item_Provider_Cb itemProviderCallback;

                itemProviderCallback = (d, o, t) =>
                {
                    return func?.Invoke(t);
                };
                Interop.Elementary.elm_entry_item_provider_prepend(RealHandle, itemProviderCallback, IntPtr.Zero);
                _itemsProvider.Add(func, itemProviderCallback);
            }
        }

        /// <summary>
        /// This removes a custom item provider to the list for that entry.
        /// </summary>
        /// <param name="func">This function is used to provide items.</param>
        public void RemoveItemProvider(Func<string, EvasObject> func)
        {
            if (_itemsProvider.ContainsKey(func))
            {
                Interop.Elementary.Elm_Entry_Item_Provider_Cb itemProviderCallback;
                _itemsProvider.TryGetValue(func, out itemProviderCallback);

                Interop.Elementary.elm_entry_item_provider_remove(RealHandle, itemProviderCallback, IntPtr.Zero);
                _itemsProvider.Remove(func);
            }
        }

        /// <summary>
        /// Append a markup filter function for text inserted in the entry.
        /// </summary>
        /// <param name="filter">This function type is used by entry filters to modify text.</param>
        public void AppendMarkUpFilter(Func<Entry, string, string> filter)
        {
            if (!_textFilters.ContainsKey(filter))
            {
                Interop.Elementary.Elm_Entry_Filter_Cb textFilterCallback = (IntPtr d, IntPtr e, ref IntPtr t) =>
                {
                    var text = Marshal.PtrToStringAnsi(t);

                    var updateText = filter(this, text);

                    if (updateText != text)
                    {
                        Interop.Libc.Free(t);
                        t = Marshal.StringToHGlobalAnsi(updateText);
                    }
                };
                Interop.Elementary.elm_entry_markup_filter_append(RealHandle, textFilterCallback, IntPtr.Zero);
                _textFilters.Add(filter, textFilterCallback);
            }
        }

        /// <summary>
        /// Prepend a markup filter function for text inserted in the entry.
        /// </summary>
        /// <param name="filter">This function type is used by entry filters to modify text.</param>
        public void PrependMarkUpFilter(Func<Entry, string, string> filter)
        {
            if (!_textFilters.ContainsKey(filter))
            {
                Interop.Elementary.Elm_Entry_Filter_Cb textFilterCallback = (IntPtr d, IntPtr e, ref IntPtr t) =>
                {
                    var text = Marshal.PtrToStringAnsi(t);

                    var updateText = filter(this, text);

                    if (updateText != text)
                    {
                        Interop.Libc.Free(t);
                        t = Marshal.StringToHGlobalAnsi(updateText);
                    }
                };
                Interop.Elementary.elm_entry_markup_filter_prepend(RealHandle, textFilterCallback, IntPtr.Zero);
                _textFilters.Add(filter, textFilterCallback);
            }
        }

        /// <summary>
        /// Remove a markup filter
        /// </summary>
        /// <param name="filter">This function type is used by entry filters to modify text.</param>
        public void RemoveMarkUpFilter(Func<Entry, string, string> filter)
        {
            if (_textFilters.ContainsKey(filter))
            {
                Interop.Elementary.Elm_Entry_Filter_Cb textFilterCallback;
                _textFilters.TryGetValue(filter, out textFilterCallback);

                Interop.Elementary.elm_entry_markup_filter_remove(RealHandle, textFilterCallback, IntPtr.Zero);
                _textFilters.Remove(filter);
            }
        }

        /// <summary>
        /// This executes a "copy" action on the selected text in the entry.
        /// </summary>
        public void CopySelection()
        {
            Interop.Elementary.elm_entry_selection_copy(RealHandle);
        }

        /// <summary>
        /// This executes a "cut" action on the selected text in the entry.
        /// </summary>
        public void CutSelection()
        {
            Interop.Elementary.elm_entry_selection_cut(RealHandle);
        }

        /// <summary>
        /// This executes a "paste" action in the entry.
        /// </summary>
        public void PasteSelection()
        {
            Interop.Elementary.elm_entry_selection_paste(RealHandle);
        }

        /// <summary>
        /// This disabled the entry's selection.
        /// </summary>
        /// <param name="disable">If true, the selection are disabled.</param>
        public void DisableSelection(bool disable)
        {
            Interop.Elementary.elm_entry_selection_handler_disabled_set(RealHandle, disable);
        }

        /// <summary>
        /// Get any selected text within the entry.
        /// </summary>
        /// <returns>Selection's value</returns>
        public string GetSelection()
        {
            return Interop.Elementary.elm_entry_selection_get(RealHandle);
        }

        /// <summary>
        /// This selects a region of text within the entry.
        /// </summary>
        /// <param name="start">The starting position.</param>
        /// <param name="end">The end position.</param>
        public void SetSelectionRegion(int start, int end)
        {
            Interop.Elementary.elm_entry_select_region_set(RealHandle, start, end);
        }

        /// <summary>
        /// Sets the visibility of the left-side widget of the entry
        /// </summary>
        /// <param name="isDisplay">true if the object should be displayed, false if not.</param>
        public void SetIconVisible(bool isDisplay)
        {
            Interop.Elementary.elm_entry_icon_visible_set(RealHandle, isDisplay);
        }

        /// <summary>
        /// Set whether the return key on the input panel is disabled automatically when entry has no text.
        /// </summary>
        /// <param name="enable">If enabled is true, the return key is automatically disabled when the entry has no text.</param>
        public void SetInputPanelReturnKeyAutoEnable(bool enable)
        {
            Interop.Elementary.elm_entry_input_panel_return_key_autoenabled_set(RealHandle, enable);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject</param>
        /// <returns>Handle IntPtr</returns>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_entry_add(parent.Handle);
        }

        #region IScroller Implementation

        /// <summary>
        /// Scrolled will be triggered when the content has been scrolled.
        /// </summary>
        public event EventHandler Scrolled
        {
            add => _scroller.Scrolled += value;
            remove => _scroller.Scrolled -= value;
        }

        /// <summary>
        /// DragStart will be triggered when dragging the contents around has started.
        /// </summary>
        public event EventHandler DragStart
        {
            add => _scroller.DragStart += value;
            remove => _scroller.DragStart -= value;
        }

        /// <summary>
        /// DragStop will be triggered when dragging the contents around has stopped.
        /// </summary>
        public event EventHandler DragStop
        {
            add => _scroller.DragStop += value;
            remove => _scroller.DragStop -= value;
        }

        /// <summary>
        /// PageScrolled will be triggered when the visible page has changed.
        /// </summary>
        public event EventHandler PageScrolled
        {
            add => _scroller.PageScrolled += value;
            remove => _scroller.PageScrolled -= value;
        }

        /// <summary>
        /// Gets the current region in the content object that is visible through the Scroller.
        /// </summary>
        public Rect CurrentRegion => _scroller.CurrentRegion;

        /// <summary>
        /// Sets or gets the value of HorizontalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the horizontal scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        public virtual ScrollBarVisiblePolicy HorizontalScrollBarVisiblePolicy
        {
            get => _scroller.HorizontalScrollBarVisiblePolicy;
            set => _scroller.HorizontalScrollBarVisiblePolicy = value;
        }

        /// <summary>
        /// Sets or gets the value of VerticalScrollBarVisiblePolicy
        /// </summary>
        /// <remarks>
        /// ScrollBarVisiblePolicy.Auto means the vertical scrollbar is made visible if it is needed, and otherwise kept hidden.
        /// ScrollBarVisiblePolicy.Visible turns it on all the time, and ScrollBarVisiblePolicy.Invisible always keeps it off.
        /// </remarks>
        public virtual ScrollBarVisiblePolicy VerticalScrollBarVisiblePolicy
        {
            get => _scroller.VerticalScrollBarVisiblePolicy;
            set => _scroller.VerticalScrollBarVisiblePolicy = value;
        }

        /// <summary>
        /// Sets or gets the value of ScrollBlock.
        /// </summary>
        /// <remarks>
        /// This function will block scrolling movement  in a given direction.One can disable movements in the X axis, the Y axis or both.
        /// The default value is ScrollBlock.None, where movements are allowed in both directions.
        /// </remarks>
        public ScrollBlock ScrollBlock
        {
            get => _scroller.ScrollBlock;
            set => _scroller.ScrollBlock = value;
        }

        /// <summary>
        /// Sets or gets scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the top of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the top of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
        public int VerticalPageIndex => _scroller.VerticalPageIndex;

        /// <summary>
        /// Sets or gets scroll current page number.
        /// </summary>
        /// <remarks>
        /// Current page means the page which meets the left of the viewport.
        /// If there are two or more pages in the viewport, it returns the number of the page which meets the left of the viewport.
        /// The page number starts from 0. 0 is the first page.
        /// </remarks>
        public int HorizontalPageIndex => _scroller.HorizontalPageIndex;

        /// <summary>
        /// Sets or gets the maximum limit of the movable page at vertical direction.
        /// </summary>
        public int VerticalPageScrollLimit
        {
            get => _scroller.VerticalPageScrollLimit;
            set => _scroller.VerticalPageScrollLimit = value;
        }

        /// <summary>
        /// Sets or gets the maximum limit of the movable page at horizontal direction.
        /// </summary>
        public int HorizontalPageScrollLimit
        {
            get => _scroller.HorizontalPageScrollLimit;
            set => _scroller.HorizontalPageScrollLimit = value;
        }

        /// <summary>
        /// Sets or gets the vertical bounce behaviour.
        /// When scrolling, the scroller may "bounce" when reaching an edge of the content object.
        /// This is a visual way to indicate the end has been reached.
        /// This is enabled by default for both axis.
        /// This API will set if it is enabled for the given axis with the boolean parameters for each axis.
        /// </summary>
        public bool VerticalBounce
        {
            get => _scroller.VerticalBounce;
            set => _scroller.VerticalBounce = value;
        }

        /// <summary>
        /// Sets or gets the horizontal bounce behaviour.
        /// When scrolling, the scroller may "bounce" when reaching an edge of the content object.
        /// This is a visual way to indicate the end has been reached.
        /// This is enabled by default for both axis.
        /// This API will set if it is enabled for the given axis with the boolean parameters for each axis.
        /// </summary>
        public bool HorizontalBounce
        {
            get => _scroller.HorizontalBounce;
            set => _scroller.HorizontalBounce = value;
        }

        /// <summary>
        /// Gets the width of the content object of the scroller.
        /// </summary>
        public int ChildWidth
        {
            get => _scroller.ChildWidth;
        }

        /// <summary>
        /// Gets the height of the content object of the scroller.
        /// </summary>
        public int ChildHeight
        {
            get => _scroller.ChildHeight;
        }

        /// <summary>
        /// Set scrolling gravity values for a scroller.
        /// The gravity, defines how the scroller will adjust its view when the size of the scroller contents increase.
        /// The scroller will adjust the view to glue itself as follows.
        /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the rigth edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
        /// Default values for x and y are 0.0
        /// </summary>
        public double HorizontalGravity
        {
            get => _scroller.HorizontalGravity;
            set => _scroller.HorizontalGravity = value;
        }

        /// <summary>
        /// Set scrolling gravity values for a scroller.
        /// The gravity, defines how the scroller will adjust its view when the size of the scroller contents increase.
        /// The scroller will adjust the view to glue itself as follows.
        /// x=0.0, for staying where it is relative to the left edge of the content x=1.0, for staying where it is relative to the rigth edge of the content y=0.0, for staying where it is relative to the top edge of the content y=1.0, for staying where it is relative to the bottom edge of the content
        /// Default values for x and y are 0.0
        /// </summary>
        public double VerticalGravity
        {
            get => _scroller.VerticalGravity;
            set => _scroller.VerticalGravity = value;
        }

        /// <summary>
        /// Get scroll last page number.
        /// The page number starts from 0. 0 is the first page. This returns the last page number among the pages.
        /// </summary>
        public int LastVerticalPageNumber => _scroller.LastVerticalPageNumber;

        /// <summary>
        /// Get scroll last page number.
        /// The page number starts from 0. 0 is the first page. This returns the last page number among the pages.
        /// </summary>
        public int LastHorizontalPageNumber => _scroller.LastHorizontalPageNumber;

        /// <summary>
        /// Set an infinite loop_ for a scroller.
        /// This function sets the infinite loop vertically.
        /// If the content is set, it will be shown repeatedly.
        /// </summary>
        public bool VerticalLoop
        {
            get => _scroller.VerticalLoop;
            set => _scroller.VerticalLoop = value;
        }

        /// <summary>
        /// Set an infinite loop_ for a scroller.
        /// This function sets the infinite loop horizontally.
        /// If the content is set, it will be shown repeatedly.
        /// </summary>
        public bool HorizontalLoop
        {
            get => _scroller.HorizontalLoop;
            set => _scroller.HorizontalLoop = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int HorizontalPageSize
        {
            get => _scroller.HorizontalPageSize;
            set => _scroller.HorizontalPageSize = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int VerticalPageSize
        {
            get => _scroller.VerticalPageSize;
            set => _scroller.VerticalPageSize = value;
        }

        /// <summary>
        /// Gets or sets a given scroller widget's scrolling page size, relative to its viewport size.
        /// </summary>
        public double VerticalRelativePageSize
        {
            get => _scroller.VerticalRelativePageSize;
            set => _scroller.VerticalRelativePageSize = value;
        }

        /// <summary>
        /// Gets or sets a given scroller widget's scrolling page size, relative to its viewport size.
        /// </summary>
        public double HorizontalRelativePageSize
        {
            get => _scroller.HorizontalRelativePageSize;
            set => _scroller.HorizontalRelativePageSize = value;
        }

        /// <summary>
        /// Gets or Sets the page snapping behavior of a scroller.
        /// </summary>
        /// <remarks>
        /// When scrolling, if a scroller is paged (see VerticalRelativePageSize),
        /// the scroller may snap to pages when being scrolled, i.e., even if it had momentum to scroll further,
        /// it will stop at the next page boundaries. This is disabled, by default, for both axis.
        /// This function will set if it that is enabled or not, for each axis.
        /// </remarks>
        public bool VerticalSnap
        {
            get => _scroller.VerticalSnap;
            set => _scroller.VerticalSnap = value;
        }

        /// <summary>
        /// Gets or Sets the page snapping behavior of a scroller.
        /// </summary>
        /// <remarks>
        /// When scrolling, if a scroller is paged (see HorizontalRelativePageSize),
        /// the scroller may snap to pages when being scrolled, i.e., even if it had momentum to scroll further,
        /// it will stop at the next page boundaries. This is disabled, by default, for both axis.
        /// This function will set if it that is enabled or not, for each axis.
        /// </remarks>
        public bool HorizontalSnap
        {
            get => _scroller.HorizontalSnap;
            set => _scroller.HorizontalSnap = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int PageHeight
        {
            get => _scroller.PageHeight;
            set => _scroller.PageHeight = value;
        }

        /// <summary>
        /// Gets or sets the page size to an absolute fixed value, with 0 turning it off for that axis.
        /// </summary>
        public int PageWidth
        {
            get => _scroller.PageWidth;
            set => _scroller.PageWidth = value;
        }

        /// <summary>
        /// Gets or sets the step size to move scroller by key event.
        /// </summary>
        public int HorizontalStepSize
        {
            get => _scroller.HorizontalStepSize;
            set => _scroller.HorizontalStepSize = value;
        }

        /// <summary>
        /// Gets or sets the step size to move scroller by key event.
        /// </summary>
        public int VerticalStepSize
        {
            get => _scroller.VerticalStepSize;
            set => _scroller.VerticalStepSize = value;
        }

        /// <summary>
        /// Gets or sets a value whether mouse wheel is enabled or not over the scroller.
        /// </summary>
        public bool WheelDisabled
        {
            get => _scroller.WheelDisabled;
            set => _scroller.WheelDisabled = value;
        }

        /// <summary>
        /// Gets or sets the type of single direction scroll.
        /// </summary>
        public ScrollSingleDirection SingleDirection
        {
            get => _scroller.SingleDirection;
            set => _scroller.SingleDirection = value;
        }

        /// <summary>
        /// Sets the scroller minimum size limited to the minimum size of the content.
        /// By default the scroller will be as small as its design allows, irrespective of its content.
        /// This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.
        /// </summary>
        /// <param name="horizontal">Enable limiting minimum size horizontally</param>
        /// <param name="vertical">Enable limiting minimum size vertically</param>
        public void MinimumLimit(bool horizontal, bool vertical)
        {
            _scroller.MinimumLimit(horizontal, vertical);
        }

        /// <summary>
        /// Shows a specific virtual region within the scroller content object by the page number.
        /// (0, 0) of the indicated page is located at the top-left corner of the viewport.
        /// </summary>
        /// <param name="horizontalPageIndex">The horizontal page number.</param>
        /// <param name="verticalPageIndex">The vertical page number.</param>
        /// <param name="animated">True means slider with animation.</param>
        public void ScrollTo(int horizontalPageIndex, int verticalPageIndex, bool animated)
        {
            _scroller.ScrollTo(horizontalPageIndex, verticalPageIndex, animated);
        }

        /// <summary>
        /// Shows a specific virtual region within the scroller content object.
        /// </summary>
        /// <remarks>
        /// This ensures that all (or part, if it does not fit) of the designated region in the virtual content object ((0, 0)
        /// starting at the top-left of the virtual content object) is shown within the scroller.
        /// If set "animated" to true, it will allows the scroller to "smoothly slide" to this location
        /// (if configuration in general calls for transitions).
        /// It may not jump immediately to the new location and may take a while and show other content along the way.
        /// </remarks>
        /// <param name="region">Rect struct of region.</param>
        /// <param name="animated">True means allows the scroller to "smoothly slide" to this location.</param>
        public void ScrollTo(Rect region, bool animated)
        {
            _scroller.ScrollTo(region, animated);
        }

        #endregion
    }
}
﻿using Microsoft.JSInterop;

namespace ComponentsLibrary;

public static class BlazorLocalStorage
{
    public static ValueTask<T> GetAsync<T>(IJSRuntime jsRuntime, string key)
            => jsRuntime.InvokeAsync<T>("blazorLocalStorage.get", key);

    public static ValueTask SetAsync(IJSRuntime jsRuntime, string key, object value)
            => jsRuntime.InvokeVoidAsync("blazorLocalStorage.set", key, value);

    public static ValueTask DeleteAsync(IJSRuntime jsRuntime, string key)
            => jsRuntime.InvokeVoidAsync("blazorLocalStorage.delete", key);
}

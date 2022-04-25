# IResourceFilter 
+ 控制器方法同步缓存处理
+ 执行顺序
    1. 控制器构造函数
    2. OnResourceExecuting
    3. Action
    4. OnResourceExecuted
```C#
```

# IAsyncResourceFilter
+ 控制器方法异步缓存处理
+ 执行顺序
    1. OnResourceExecutingAsync
        1. 执行方法前
        2. ResourceExecutedContext executedContext = await next.Invoke()
            1. 控制器构造函数
            2. 控制器方法
        3.执行方法后
```C#
```

# IActionFilter
+ 同步控制器方法处理
+ 时候记录Action日志，贴近Action
+ 执行顺序
    1. 控制器构造函数
    2. OnActionExcuting
    3. Action
    4. OnActionExcuted
```C#
````

# IAsyncActionFilter
+ 异步控制器方法处理
+ 时候记录Action日志，贴近Action
+ 执行顺序
    1. OnActionExecutionAsync
        1. 执行方法前
        2. ActionExecutedContext executedContext = await next.Invoke()
            1. 控制器构造函数
            2. 控制器方法
        3. 执行方法后
```C#

# IResultFilter

```C#
```

# IAsyncResultFilter

```C#
```

# IExceptionFilter

```C#
```

# IAsyncExceptionFilter

```C#
```
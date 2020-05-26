# ReplaceEmbeddedAssemblyResource

A small .NET Core program to replace embedded resources inside .NET assemblies.

## How to build

    dotnet build

## How to use

    dotnet bin/Debug/netcoreapp3.1/ReplaceEmbeddedAssemblyResource.dll <Assembly-Path> <New-Assembly-Path> <Resource-Name> <Resource-Path> [-snk <Strong-Name-Key-Path>]

Example arguments: 

    Assembly.dll NewAssembly.dll Acme.Project.data.bin data.bin
    SignedAssembly.dll NewAssembly.dll Acme.Project.data.bin data.bin -snk KeyFile.snk

## License

Copyright (c) 2013, Digifort Sverige AB  
Copyright (c) 2015, [dee-see](https://github.com/dee-see/)  
Copyright (c) 2020, Christoffer Sawicki  
All rights reserved.

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.
* Redistributions in binary
  form must reproduce the above copyright notice, this list of conditions and the
  following disclaimer in the documentation and/or other materials provided with
  the distribution.
* Neither the name of the Digifort Sverige AB nor the names of
  its contributors may be used to endorse or promote products derived from this
  software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

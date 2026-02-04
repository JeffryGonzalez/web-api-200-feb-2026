using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.SoftwareCenter;


public record VendorCreated(Guid Id, string Name);
public record VendorDeactivated(Guid Id);

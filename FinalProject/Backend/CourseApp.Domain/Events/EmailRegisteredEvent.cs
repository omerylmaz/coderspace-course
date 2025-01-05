using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Domain.Events;

public record EmailRegisteredEvent(string To, string Subject, string Body);
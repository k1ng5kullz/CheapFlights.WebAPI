﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapFlights.Domain.DTOs;

public record RetrieveBookingRequestDto(string BookingId, string ContactEmail);

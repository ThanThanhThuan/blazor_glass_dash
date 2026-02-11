## React Dashboard Interactive

View live at: https://thanthanhthuan.github.io/blazor_glass_dash/

Click Billing Admin to add/ edit/ delete billing records

See live Billing History at Settings -> Billing

<img width="1873" height="1026" alt="image" src="https://github.com/user-attachments/assets/77c1f902-d97a-401c-ac65-26e622488608" />

This project is a high-performance 3D Glassmorphism Admin Dashboard ported from a static HTML template (https://templatemo.com/tm-607-glass-admin ) into a modern, full-stack Blazor WebAssembly (WASM) application using .NET 8/9.
The application demonstrates how to bridge high-end CSS design with robust C# backend logic, reactive state management, and real-time API integration.

🚀 1. Technical Stack

Framework: Blazor WebAssembly (WASM) - Client-side C#.
Language: C# 12 / .NET 8+.
State Management: Scoped Service (AppState.cs) using the observer pattern (replacing Vue's Pinia).
API Integration: HttpClient with System.Text.Json for RESTful communication.
Backend: nocodebackend.com (PostgreSQL/SQL logic via REST).
Interoperability: JavaScript Interop for hardware-accelerated 3D tilt effects.

📊 2. Key Features

Dynamic Dashboard: Unified interface displaying real-time metrics, interactive revenue charts (CSS-driven), and project progress trackers.
Advanced Analytics: Visual data representations including a 30-day traffic bar chart, custom SVG donut charts for device breakdown, and geographic performance stats.
User Management: Full-featured management console with dynamic status badges and gradient-based avatars.
Admin Billing (Full CRUD):
Create/Update: Unified reactive form to push/edit records in the nocodebackend instance.
Read: "Bulletproof" fetch logic that merges fixed design-time mock data with live database records.
Delete: Permanent record removal with JS-native confirmation dialogs.
Theme Engine: Global Dark/Light mode synchronization across all components via CSS variables and the data-theme attribute.

🏗️ 3. Architecture Highlights

DataService.cs (Business Logic): Centralized service handling all data concerns. It includes robust JSON deserialization logic to handle API "envelopes" and safe type conversion (converting API strings into C# doubles).
AppState.cs (Global State): Manages UI-wide states like Sidebar visibility and Theme selection. Components subscribe to an OnChange event to trigger re-renders.
GlassCard.razor: A reusable C# wrapper component utilizing Attribute Splatting and JS Interop to apply 3D mouse-tracking effects to any nested content.
Safe Data Merging: Intelligent sorting logic that uses DateTime.TryParse to combine disparate data sources (Mock vs DB) into a single, chronologically sorted stream.

🛠️ 4. Data Flow & Security

Encapsulated API Logic: Uses [JsonPropertyName] to map lowercase JSON keys from the database to PascalCase C# properties.
Handling API Diversity: Implemented a BillingResponse wrapper to "dig out" data arrays nested within API status objects.
Environment Configuration: Utilizes appsettings.json for local development and GitHub Actions Variable Substitution for secure production deployment on GitHub Pages.

🎨 5. User Experience (UX)

Zero-Latency UI: Blazor’s client-side execution ensures that tab switching and theme toggling happen instantly.
Smart Date Logic: Automated calculation of the "Next Billing Date" using C# DateTime math to always display the 1st of the upcoming month.
Current Status: The project is a production-ready, enterprise-grade dashboard. It successfully abstracts complex frontend interactions into maintainable C# code while preserving a cutting-edge "Glassmorphism" aesthetic. It is fully deployable via automated CI/CD pipelines.



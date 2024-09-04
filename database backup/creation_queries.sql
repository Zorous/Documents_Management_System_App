


CREATE TABLE tenants (
    tenant_id SERIAL PRIMARY KEY,
    tenant_name VARCHAR(255) NOT NULL,
    domain VARCHAR(255) UNIQUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);



CREATE TABLE users (
    user_id SERIAL PRIMARY KEY,
    tenant_id INT REFERENCES tenants(tenant_id) ON DELETE CASCADE,
    user_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);



CREATE TABLE roles (
    role_id SERIAL PRIMARY KEY,
    tenant_id INT REFERENCES tenants(tenant_id) ON DELETE CASCADE,
    role_name VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE permissions (
    permission_id SERIAL PRIMARY KEY,
    permission_name VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);



CREATE TABLE user_roles (
    user_role_id SERIAL PRIMARY KEY,
    user_id INT REFERENCES users(user_id) ON DELETE CASCADE,
    role_id INT REFERENCES roles(role_id) ON DELETE CASCADE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE role_permissions (
    role_permission_id SERIAL PRIMARY KEY,
    role_id INT REFERENCES roles(role_id) ON DELETE CASCADE,
    permission_id INT REFERENCES permissions(permission_id) ON DELETE CASCADE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);



CREATE TABLE documents (
    document_id SERIAL PRIMARY KEY,
    tenant_id INT REFERENCES tenants(tenant_id) ON DELETE CASCADE,
    document_name VARCHAR(255) NOT NULL,
    content TEXT,
    created_by INT REFERENCES users(user_id) ON DELETE SET NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE document_access (
    document_access_id SERIAL PRIMARY KEY,
    document_id INT REFERENCES documents(document_id) ON DELETE CASCADE,
    user_id INT REFERENCES users(user_id) ON DELETE CASCADE,
    access_level VARCHAR(50) NOT NULL,  -- e.g., 'read', 'write', 'admin'
    granted_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE payments (
    payment_id SERIAL PRIMARY KEY,
    tenant_id INT REFERENCES tenants(tenant_id) ON DELETE CASCADE,
    payment_method VARCHAR(255),
    payment_status VARCHAR(50),
    amount DECIMAL(10, 2),
    paid_at TIMESTAMP,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);





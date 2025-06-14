PGDMP  7    (                }            Maggot    17.4    17.4     6           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            7           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            8           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            9           1262    17059    Maggot    DATABASE     n   CREATE DATABASE "Maggot" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en-US';
    DROP DATABASE "Maggot";
                     postgres    false            �            1259    17061    admin    TABLE     �   CREATE TABLE public.admin (
    id_admin integer NOT NULL,
    nama_admin character varying(100) NOT NULL,
    username character varying(60) NOT NULL,
    password character varying(60) NOT NULL,
    no_hp character varying(14) NOT NULL
);
    DROP TABLE public.admin;
       public         heap r       postgres    false            �            1259    17060    admin_id_admin_seq    SEQUENCE     �   CREATE SEQUENCE public.admin_id_admin_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.admin_id_admin_seq;
       public               postgres    false    218            :           0    0    admin_id_admin_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.admin_id_admin_seq OWNED BY public.admin.id_admin;
          public               postgres    false    217            �            1259    17084    id_pembeli_seq    SEQUENCE     w   CREATE SEQUENCE public.id_pembeli_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.id_pembeli_seq;
       public               postgres    false            �            1259    17082    id_penjual_seq    SEQUENCE     w   CREATE SEQUENCE public.id_penjual_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.id_penjual_seq;
       public               postgres    false            �            1259    17076    pembeli    TABLE     j  CREATE TABLE public.pembeli (
    id_pembeli integer DEFAULT nextval('public.id_pembeli_seq'::regclass) NOT NULL,
    nama_pembeli character varying(100) NOT NULL,
    username character varying(60) NOT NULL,
    password character varying(60) NOT NULL,
    no_telepon_pembeli character varying(13) NOT NULL,
    email_pembeli character varying(100) NOT NULL
);
    DROP TABLE public.pembeli;
       public         heap r       postgres    false    224            �            1259    17075    pembeli_id_pembeli_seq    SEQUENCE     �   CREATE SEQUENCE public.pembeli_id_pembeli_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.pembeli_id_pembeli_seq;
       public               postgres    false    222            ;           0    0    pembeli_id_pembeli_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.pembeli_id_pembeli_seq OWNED BY public.pembeli.id_pembeli;
          public               postgres    false    221            �            1259    17068    penjual    TABLE     i  CREATE TABLE public.penjual (
    id_penjual integer DEFAULT nextval('public.id_penjual_seq'::regclass) NOT NULL,
    nama_penjual character varying(60) NOT NULL,
    username character varying(60) NOT NULL,
    password character varying(60) NOT NULL,
    no_telepon_penjual character varying(13) NOT NULL,
    email_penjual character varying(100) NOT NULL
);
    DROP TABLE public.penjual;
       public         heap r       postgres    false    223            �            1259    17067    penjual_id_penjual_seq    SEQUENCE     �   CREATE SEQUENCE public.penjual_id_penjual_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.penjual_id_penjual_seq;
       public               postgres    false    220            <           0    0    penjual_id_penjual_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.penjual_id_penjual_seq OWNED BY public.penjual.id_penjual;
          public               postgres    false    219            �           2604    17064    admin id_admin    DEFAULT     p   ALTER TABLE ONLY public.admin ALTER COLUMN id_admin SET DEFAULT nextval('public.admin_id_admin_seq'::regclass);
 =   ALTER TABLE public.admin ALTER COLUMN id_admin DROP DEFAULT;
       public               postgres    false    217    218    218            -          0    17061    admin 
   TABLE DATA           P   COPY public.admin (id_admin, nama_admin, username, password, no_hp) FROM stdin;
    public               postgres    false    218   7       1          0    17076    pembeli 
   TABLE DATA           r   COPY public.pembeli (id_pembeli, nama_pembeli, username, password, no_telepon_pembeli, email_pembeli) FROM stdin;
    public               postgres    false    222   T       /          0    17068    penjual 
   TABLE DATA           r   COPY public.penjual (id_penjual, nama_penjual, username, password, no_telepon_penjual, email_penjual) FROM stdin;
    public               postgres    false    220   �       =           0    0    admin_id_admin_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.admin_id_admin_seq', 1, false);
          public               postgres    false    217            >           0    0    id_pembeli_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.id_pembeli_seq', 2, true);
          public               postgres    false    224            ?           0    0    id_penjual_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.id_penjual_seq', 3, true);
          public               postgres    false    223            @           0    0    pembeli_id_pembeli_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.pembeli_id_pembeli_seq', 1, false);
          public               postgres    false    221            A           0    0    penjual_id_penjual_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.penjual_id_penjual_seq', 1, false);
          public               postgres    false    219            �           2606    17066    admin admin_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.admin
    ADD CONSTRAINT admin_pkey PRIMARY KEY (id_admin);
 :   ALTER TABLE ONLY public.admin DROP CONSTRAINT admin_pkey;
       public                 postgres    false    218            �           2606    17081    pembeli pembeli_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.pembeli
    ADD CONSTRAINT pembeli_pkey PRIMARY KEY (id_pembeli);
 >   ALTER TABLE ONLY public.pembeli DROP CONSTRAINT pembeli_pkey;
       public                 postgres    false    222            �           2606    17073    penjual penjual_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.penjual
    ADD CONSTRAINT penjual_pkey PRIMARY KEY (id_penjual);
 >   ALTER TABLE ONLY public.penjual DROP CONSTRAINT penjual_pkey;
       public                 postgres    false    220            -      x������ � �      1   R   x�3�����1���1����%B�@
�s3s���s��8�3��K�S�@�������8S
SʑT��qqq 7� j      /   q   x�3�tJ,�N,JTp��ML�,�/JIK�K/�442�4�0545346270DH9���gd�%��r�2f���9�$�s3s�z�9�3��@
��1H_6HIi� .�5)     
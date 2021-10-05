use drinkandmeal

select 
Blogers.banner_img,
Blogers.cooking_time,
Blogers.category_id,
Blogers.cover_img,
Blogers.create_at,
Blogers.create_at,
Blogers.description,
Blogers.id,
Blogers.name,
Blogers.status,
Blogers.summary,
Blogers.update_at,
Blogers.url_video_utube,
Blogers.user_id,
Blogers.[view],

contents.name as 'content_name',
contents.banner_cover as 'content_banner_cover',
contents.banner_img as 'content_banner_img',
contents.content as 'content_content',
contents.id as 'content_content',

metarials.id as 'metarials_id',
metarials.mass as 'metarials_mass',
metarials.title as 'metarials_title',
metarials.unit as 'metarials_unit',
metarials.[order] as 'content_content',

Step.banner_img as 'Step_banner_img',
Step.blog_id as 'Step_blog_id',
Step.desciption as 'Step_desciption',
Step.id as 'Step_id',
Step.name as 'Step_name',
Step.[order] as 'Step_order'

from Blogers
inner join contents on contents.blog_id = Blogers.id
inner join metarials on metarials.blog_id = Blogers.id
inner join Step on Step.blog_id = Blogers.id
where Blogers.id = 6

select * from ImgProductFeature
inner join ImgProductFeature on ImgProductFeature.product_id = products.id